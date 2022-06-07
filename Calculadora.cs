public class Calculadora{
        private double Resultado;

        public double Sumar (double termino){
            Resultado=Resultado+termino;
            return Resultado;
        }
        public double Restar (double termino){
            Resultado=Resultado-termino;
            return Resultado;
        }
        public double Multiplicar (double termino){
            Resultado=Resultado*termino;
            return Resultado;
        }
        public double Dividir (double termino){
            Resultado=Resultado/termino;
            return Resultado;
        }
        public void Limpiar (){
            Resultado=0;
        }
        public double Acceder(){
            return Resultado;
        }
    }
