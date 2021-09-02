using System;
using System.Runtime.InteropServices;


namespace TP2_Herrera_Leonel
{
    public class Empleado
    {
        private static float salarioBasico = 5000;
        private static float descuento = 0.15f;

        string nombre;
        string apellido;
        string direccion;
        DateTime fechaDeIngreso;
        private DateTime fechaNacimiento;
        private int edad;
        private int antiguedad;
        private float salario;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaIngreso { get => fechaDeIngreso; set => fechaDeIngreso = value; }
        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public int Edad { get => edad; set => edad = value; }
        public float Salario { get => salario; set => salario = value; }



        public Empleado(string nombre, string apellido, string direccion, DateTime fechaNacimiento, DateTime fechaDeIngreso)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaDeIngreso = fechaDeIngreso;
            this.fechaNacimiento = fechaNacimiento;
            antiguedad = CalcularAntiguedad();
            edad = CalcularEdad();
            salario = CalcularSalario();
        }

        private int CalcularAntiguedad()
        {
            return CalcularAños(fechaDeIngreso, DateTime.Now);
        }

        private int CalcularEdad()
        {
            return CalcularAños(fechaNacimiento, DateTime.Now);
        }


        private int CalcularAños(DateTime desde, DateTime hasta)
        {
            int ant = hasta.Year - desde.Year;
            if (hasta.Month < desde.Month || (hasta.Month == desde.Month && hasta.Day < desde.Day))
                ant--;
            return ant;
        }

        private float CalcularSalario()
        {
            float adicional = 0;
            if (antiguedad < 20)
            {
                adicional = salarioBasico * (antiguedad / 100f);
            }
            else
            {
                adicional = salarioBasico * 0.25f;
            }
            float salario = (salarioBasico + adicional) - (salarioBasico * -descuento);
            return salario;
        }
        /*
        public float CalcularSalario()
        {
            float descuento = (float)(sueldoBasico * 0.15);
            int ant = CalcularAntiguedad();
            float adicional = (float)(ant > 20 ? sueldoBasico * 0.25 : sueldoBasico * ant / 100.0);


            return sueldoBasico + adicional - descuento;
        }
        */
        /*
        public void MostrarEmpleado()
        {
            Console.WriteLine("Apellido y nombre: {0},{1}\n" +
                "Edad: {2}\nAntigüedad: {3}\nSalario: {4}\n"
                , apellido, nombre, CalcularEdad(), CalcularAntiguedad(), CalcularSalario());
        }
        */
    }
}
