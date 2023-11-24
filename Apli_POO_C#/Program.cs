using System;
using System.Collections.Generic;

// Definición de la interfaz
interface IMostrarInformacion
{
    void MostrarInformacion();
}

// Definición de la clase Empleado
class Empleado : IMostrarInformacion
{
    public string Nombre { get; set; }
    public double Salario { get; set; }

    public Empleado(string nombre, double salario)
    {
        Nombre = nombre;
        Salario = salario;
    }

    public double CalcularSalarioAnual()
    {
        return Salario * 12;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Salario: {Salario:C}, Salario Anual: {CalcularSalarioAnual():C}");
    }
}

// Definición de la clase Gerente que hereda de Empleado
class Gerente : Empleado, IMostrarInformacion
{
    public string Departamento { get; set; }

    public Gerente(string nombre, double salario, string departamento) : base(nombre, salario)
    {
        Departamento = departamento;
    }

    public new void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Departamento: {Departamento}");
    }
}

class Program
{
    static List<Empleado> empleados = new List<Empleado>();
    static List<Gerente> gerentes = new List<Gerente>();

    static void Main()
    {
        Console.WriteLine("Primero tienes que crear todos los empleados y gerentes:");
        int opcion;

        do
        {
            Console.WriteLine("1. Crear nuevo empleado");
            Console.WriteLine("2. Crear nuevo gerente");
            Console.WriteLine("3. Ver todos los empleados");
            Console.WriteLine("4. Ver todos los gerentes");
            Console.WriteLine("5. Ver todos");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese la opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearNuevoEmpleado();
                    break;
                case 2:
                    CrearNuevoGerente();
                    break;
                case 3:
                    VerTodosLosEmpleados();
                    break;
                case 4:
                    VerTodosLosGerentes();
                    break;
                case 5:
                    VerTodos();
                    break;
                case 6:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 6);
    }

    static void CrearNuevoEmpleado()
    {
        Console.Write("Ingrese el nombre del empleado: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el salario del empleado: ");
        double salario = double.Parse(Console.ReadLine());

        Empleado nuevoEmpleado = new Empleado(nombre, salario);
        empleados.Add(nuevoEmpleado);
        Console.WriteLine("Empleado creado exitosamente.");
    }

    static void CrearNuevoGerente()
    {
        Console.Write("Ingrese el nombre del gerente: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el salario del gerente: ");
        double salario = double.Parse(Console.ReadLine());
        Console.Write("Ingrese el departamento del gerente: ");
        string departamento = Console.ReadLine();

        Gerente nuevoGerente = new Gerente(nombre, salario, departamento);
        gerentes.Add(nuevoGerente);
        Console.WriteLine("Gerente creado exitosamente.");
    }

    static void VerTodosLosEmpleados()
    {
        Console.WriteLine("Información de todos los empleados:");
        foreach (var empleado in empleados)
        {
            empleado.MostrarInformacion();
        }
    }

    static void VerTodosLosGerentes()
    {
        Console.WriteLine("Información de todos los gerentes:");
        foreach (var gerente in gerentes)
        {
            gerente.MostrarInformacion();
        }
    }

    static void VerTodos()
    {
        Console.WriteLine("Información de todos los empleados y gerentes:");
        foreach (var empleado in empleados)
        {
            empleado.MostrarInformacion();
        }
        foreach (var gerente in gerentes)
        {
            gerente.MostrarInformacion();
        }
    }
}


// Crear instancias de Empleado y Gerente
/*Empleado empleado = new Empleado("Diego Recalde", 50000);
Gerente gerente = new Gerente("Matias Palacios", 80000, "Ventas");
Empleado empleado1 = new Empleado("David Cantuna", 50000);
Gerente gerente1 = new Gerente("Maria Villareal", 80000, "Ventas");
Empleado empleado2 = new Empleado("Pedro Perez", 50000);
Gerente gerente2 = new Gerente("Carmen Fernandez", 80000, "Ventas");*/