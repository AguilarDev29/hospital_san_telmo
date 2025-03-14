using System;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.modelo
{
    public class Turno
    {
        private int id;
        private int idPaciente;
        private int idMedico;
        private DateTime fechaTurno;
        private int idHoraTurno;
        private decimal total;
        private string atendido;

        public int Id { get => id; set => id = value; }
        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public int IdMedico { get => idMedico; set => idMedico = value; }
        public DateTime FechaTurno { get => fechaTurno; set => fechaTurno = value; }
        public int IdHoraTurno { get => idHoraTurno; set => idHoraTurno = value; }
        public decimal Total { get => total; set => total = value; }
        public string Atendido { get => atendido; set => atendido = value; }

        public Turno() { }

        public Turno(int id, int idPaciente, int idMedico, DateTime fechaTurno, int idHoraTurno,
            decimal total)
        {
            this.id = id;
            this.idPaciente = idPaciente;
            this.idMedico = idMedico;
            this.fechaTurno = fechaTurno;
            this.idHoraTurno = idHoraTurno;
            this.total = total;
        }

        public Turno(int idPaciente, int idMedico, DateTime fechaTurno, int idHoraTurno, decimal total)
        {
            this.idPaciente = idPaciente;
            this.idMedico = idMedico;
            this.fechaTurno = fechaTurno;
            this.idHoraTurno = idHoraTurno;
            this.total = total;
        }

        public Turno(int id, DateTime fechaTurno, int idHoraTurno)
        {
            this.id = id;
            this.fechaTurno = fechaTurno;
            this.idHoraTurno = idHoraTurno;
        }

    }
}
