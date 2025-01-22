USE hospital_san_telmo;
CREATE TABLE medico (
  id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
  apellido VARCHAR(100) NOT NULL,
  nombre VARCHAR(100) NOT NULL, 
  dni VARCHAR(15) NOT NULL UNIQUE,
  especialidad VARCHAR(50) NOT NULL
  );

  INSERT INTO medico (apellido, nombre, dni, especialidad) VALUES 
  ('Pérez','Juan','12345678','Cardiología'),
  ('López','Maria','87654321','Pediatría'),
  ('García', 'Carlos','23456789','Neurología'),
  ('Martínez','Ana','34567890','Dermatología'),
  ('Fernández','Luis','45678901','Gastroenterología');
  
  CREATE TABLE obra_social (
  id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
  nombre VARCHAR(45) NOT NULL,
  descuento DECIMAL(4,1) NOT NULL
  );

  INSERT INTO obra_social (nombre, descuento) VALUES ('OSDE',15.50),('PAMI',20.00),('RED',10.75);

  CREATE TABLE pacientes (
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	apellido VARCHAR(100) NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	dni VARCHAR(15) NOT NULL UNIQUE,
	sexo VARCHAR(10) NOT NULL,
	direccion VARCHAR(100) NOT NULL,
	localidad VARCHAR(100) NOT NULL,
	telefono VARCHAR(20) NOT NULL,
	id_obra_social INT,
	FOREIGN KEY (id_obra_social) REFERENCES obra_social(id)
  );

  INSERT INTO pacientes (apellido, nombre, dni, sexo, direccion, localidad, telefono) VALUES 
  ('Pérez','Juan','12345678','Masculino','Calle Falsa 123','Buenos Aires','5551234'),
  ('Gómez','María','87654321','Femenino','Av. Siempreviva 742','Córdoba','5555678'),
  ('López','Pedro','23456789','Masculino','Calle Luna 12','Rosario','5559876'),
  ('Rodríguez','Ana','98765432','Femenino','Av. Sol 34','Mendoza','5553456'),
  ('Fernández','Luis','34567890','Masculino','Calle Estrella 56','Salta','5556789'),
  ('Martínez','Laura','87654322','Femenino','Av. Libertad 78','Tucumán','5554321'),
  ('Sánchez','Diego','45678901','Masculino','Calle Roca 90','La Plata','5558765'),
  ('Torres','Sofía','56789012','Femenino','Av. Paz 101','Neuquén','5552468'),
  ('Vega','Andrés','67890123','Masculino','Calle Libertador 345','San Juan','5551357'),
  ('Herrera','Carla','78901234','Femenino','Av. Mitre 456','Chaco','5559753');

  
  
  