USE hospital_san_telmo;

GO
	CREATE PROCEDURE spListar_historia_clinica(@dni_paciente VARCHAR(15))
	AS 
	BEGIN
		SELECT
			hc.diagnostico AS Diagnostico,
			t.fecha_turno AS 'Fecha de consulta'
		FROM 
			historia_clinica hc
		INNER JOIN
			turno t
		ON hc.id_turno = t.id 
		INNER JOIN 
			paciente p
		ON hc.id_paciente = p.id
		WHERE p.dni = @dni_paciente;
	END
GO

GO
	CREATE PROCEDURE spAgendar_turno(
		@id_paciente INT,
		@id_medico INT,
		@fecha_turno DATE,
		@id_horario INT,
		@total DECIMAL
	)	 
	AS
		BEGIN
			INSERT INTO turno (id_paciente, id_medico, fecha_turno, id_horario, total)
			VALUES(@id_paciente,@id_medico, @fecha_turno, @id_horario, @total);
		END
GO

GO
CREATE PROCEDURE spFiltrar_pagos(
    @fecha_inicio DATE, 
    @fecha_fin DATE, 
    @medico NVARCHAR(100) = NULL, 
    @especialidad NVARCHAR(100) = NULL
)
AS 
BEGIN
    SELECT 
        CONCAT('Dr. ', m.apellido, ', ', m.nombre) AS Medico, 
        t.total AS Pago, 
        p.fecha_pago AS 'Fecha de pago'
    FROM 
        pago p
    INNER JOIN 
        turno t ON p.id_turno = t.id
    INNER JOIN 
        medico m ON t.id_medico = m.id
    INNER JOIN 
        especialidad e ON m.id_especialidad = e.id
    WHERE 
        p.fecha_pago BETWEEN @fecha_inicio AND @fecha_fin
        AND (@medico IS NULL OR @medico = 'Seleccionar' OR CONCAT('Dr. ', m.apellido, ', ', m.nombre) = @medico)
        AND (@especialidad IS NULL OR @especialidad = 'Seleccionar' OR e.nombre = @especialidad);
END
GO

CREATE PROCEDURE spTurnos_del_dia(@fecha DATE, @id_medico INT)
AS
BEGIN
    SELECT 
		t.id AS ID,
        CONCAT(p.apellido, ', ', p.nombre) AS Paciente,
        p.dni AS DNI,
        t.fecha_turno AS 'Fecha de Turno',
        hc.horario AS 'Horario de Turno',
        t.atendido AS Atendido
    FROM 
        turno t
    INNER JOIN 
        paciente p ON t.id_paciente = p.id
    INNER JOIN 
        medico m ON t.id_medico = m.id
    INNER JOIN
        horario_medico hm ON t.id_horario = hm.id
    INNER JOIN
        horario_clinica hc ON hm.id_horario = hc.id
    WHERE 
        t.atendido = 'NO' 
        AND t.cancelado = 'NO' 
        AND t.ausente = 'NO'
        AND t.fecha_turno = @fecha 
        AND m.id = @id_medico
    ORDER BY 
        hc.horario DESC;
END
GO

GO
	CREATE PROCEDURE spHorarios_medico(@id_medico INT)
	AS
	BEGIN
		SELECT hm.dia AS Dia, hc.horario AS Hora, CONCAT('Dr. ', m.apellido,', ', m.nombre) AS 'Médico'
		FROM horario_medico hm INNER JOIN horario_clinica hc ON hm.id_horario = hc.id INNER JOIN medico m
		ON hm.id_medico = m.id WHERE m.id = @id_medico ORDER BY CASE dia
							WHEN 'LUNES' THEN 1 
							WHEN 'MARTES' THEN 2 
							WHEN 'MIERCOLES' THEN 3 
							WHEN 'JUEVES' THEN 4
							WHEN 'VIERNES' THEN 5
							WHEN 'SABADO' THEN 6
							WHEN 'DOMINGO' THEN 7
							END;
	END
GO
USE hospital_san_telmo;
SELECT * FROM horario_medico;
SELECT * FROM horario_clinica;



SELECT DISTINCT e.nombre 
FROM especialidad e
INNER JOIN medico m ON e.id = m.id_especialidad;
USE hospital_san_telmo


