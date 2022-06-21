public enum Cargos{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador
}

public class Empleado{
    
    private string nombre1;
    private string apellido1;
    private DateTime fechaDeNacimiento1;
    private char estadoCivil1;
    private char genero1;
    private DateTime fechaDeIngreso1;
    private double sueldo1;
    private Cargos cargo1;

    public Empleado(string nombre, string apellido, DateTime fechaDeNacimiento, char estadoCivil, char genero, DateTime fechaDeIngreso, double sueldo, Cargos cargo)
    {
        nombre1 = nombre;
        apellido1 = apellido;
        fechaDeNacimiento1 = fechaDeNacimiento;
        estadoCivil1 = estadoCivil;
        genero1 = genero;
        fechaDeIngreso1 = fechaDeIngreso;
        sueldo1 = sueldo;
        cargo1 = cargo;
    }

    public int Antiguedad(){
        DateTime fecha = DateTime.Now;
        int anio = fecha.Year - fechaDeIngreso1.Year;
        
        if(fecha.Month >= fechaDeIngreso1.Month && fecha.Day >= fechaDeIngreso1.Day){
            return anio;
        }
        return anio - 1;
    }

    public int Edad(){
        DateTime fechaDeHoy = DateTime.Now;
        int edad = fechaDeHoy.Year - fechaDeNacimiento1.Year;

        if(fechaDeHoy < fechaDeNacimiento1.AddYears(edad)){
            edad--;
        }
        return edad;
    }

    public int AniosDeJubilacion(){
        int anio = 0;

        if(genero1 == 'M'){
            anio = 65 - Edad();    
        }
        else if(genero1 == 'H'){
            anio = 60 - Edad();
        }

        return anio > 0 ? anio : 0;
    }

    public double Salario(){
        double adicional = 0;

        if(Antiguedad() <= 20){
            adicional += Antiguedad() * 0.1f * sueldo1;
        }
        else if(Antiguedad() > 20){
            adicional += sueldo1 * 0.25f;
        }

        if(cargo1 == Cargos.Ingeniero || cargo1 == Cargos.Especialista){
            adicional += sueldo1 * 0.50f;
        }

        if(estadoCivil1 == 'S'){
            adicional += 15000;
        }
        
        return sueldo1 + adicional;
    }

    public void MostrarInformacion(){
        Console.WriteLine("Nombre: " + nombre1);
        Console.WriteLine("Apellido: " + apellido1);
        Console.WriteLine("Fecha de nacimiento: " + fechaDeNacimiento1);
        Console.WriteLine("Estado Civil: " + estadoCivil1);
        Console.WriteLine("Genero: " + genero1);
        Console.WriteLine("Fecha Ingreso: " + fechaDeIngreso1);
        Console.WriteLine("Sueldo: " + Salario());
        Console.WriteLine("Cargo: " + cargo1.ToString());
    }
}

static class Program{

    public static int Main(string[] args){

        Empleado empleado1 = new Empleado("Pedro", "Jose", new DateTime(1975, 4, 3),
            'S', 'H', new DateTime(1999, 2, 2), 15000, Cargos.Administrativo);
        
        Empleado empleado2 = new Empleado("Ana", "María", new DateTime(1989, 4, 25),
            'C', 'M', new DateTime(2002, 2, 2), 14000, Cargos.Ingeniero);

        Empleado empleado3 = new Empleado("Juan", "Perez", new DateTime(2000, 7, 20),
            'S', 'H', new DateTime(2015, 5, 5), 17000, Cargos.Auxiliar);

        double totalSalarios = empleado1.Salario() + empleado2.Salario() + empleado3.Salario();
        Console.WriteLine("Total de salarios: " + totalSalarios + '\n');
        
        Console.WriteLine("Empleado más cerca de la jubliación:");
        if(empleado1.AniosDeJubilacion() <= empleado2.AniosDeJubilacion() && empleado1.AniosDeJubilacion() <= empleado3.AniosDeJubilacion()){
            empleado1.MostrarInformacion();
        }
        else if(empleado2.AniosDeJubilacion() <= empleado1.AniosDeJubilacion() && empleado2.AniosDeJubilacion() <= empleado3.AniosDeJubilacion()){
            empleado2.MostrarInformacion();
        }
        else if(empleado3.AniosDeJubilacion() <= empleado1.AniosDeJubilacion() && empleado3.AniosDeJubilacion() <= empleado2.AniosDeJubilacion()){
            empleado3.MostrarInformacion();
        }
        return 0;
    }
}