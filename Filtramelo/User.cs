using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Filtramelo
{
    public class User
    {
        public double Celular = 0;
        public bool Buscado = false;
        public static bool SeArrastroArchivo = false;
        public string Compañia = "Pendiente";
        public string Localidad = "Pendiente";
        public static List<string> ArchivoArrastrado= new List<string>();//0 = ruta sin extension del archivo, 1 = ruta//
        
        
        
        public User(double celular, bool buscado, string compañia, string localidad)
        {
            Celular = celular;
            Buscado = buscado;
            Compañia = compañia;
            Localidad = localidad;
        }
        //public static string Form2.Raiz = @"C:\Users\Admin\source\repos\Filtramelo\";


        public static int NumeroDeUsuarios = 0;
        public static List<bool> Filtros = new List<bool>();
        
        public static int LeerInfotxt(string FullPath)
        {
            int AreaError;
            if (FullPath != "")
            {
                AreaError = 1;
                User.ArchivoArrastrado.Add("");
                User.ArchivoArrastrado.Add("");
                User.ArchivoArrastrado[1] = FullPath;

                //Guardando ruta del archivo sin la extension//
                int puntos = 0;
                for (int i = 0; i < FullPath.Length; i++)
                {
                    if (FullPath[i] == 46) puntos++;
                }
                int contador = 0;
                for (int i = 0; i < FullPath.Length; i++)
                {
                    if (FullPath[i] == 46) contador++;
                    if (contador != puntos) User.ArchivoArrastrado[0] += FullPath[i];
                }
            }
            else
            {
                AreaError = 2;
                FullPath = $@"{Form2.Raiz}\Listas\Lista numeros.txt";
            }
            
            List<User> Usuarios = new List<User>();
            int fila = 0;
            string line = "";
            try
            {
                using (StreamReader file = new StreamReader(FullPath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        try
                        {
                            User user = new User(Convert.ToDouble(line), false, "P", "P");
                            Program.Usuarios.Add(user);
                        }
                        catch
                        {
                            User user = new User(0, false, "P", "P");
                            Program.Usuarios.Add(user);
                        }
                        fila++;
                    }
                }//Leyendo Archivo del FullPath//
            }
            catch
            {
                return AreaError;  
            }
            User.NumeroDeUsuarios = Program.Usuarios.Count();
            if (fila<= 0) return 3;
            return 0;
        }
        public static int GuardarInfo(int Buscados)//Guarda los "x" primeros numeros de la lista en el txt "FiltroUwu.txt"
        {
            
            int NumerosGuardados = 0;
            string FullPath;
            if (User.SeArrastroArchivo == true) FullPath = $"{User.ArchivoArrastrado[0]}" + "[Filtrado]" + ".csv";
            else FullPath = $@"{Form2.Raiz}\Listas\FiltroUwu.csv";

            try
            {
                if (Buscados == 0)//Recorre la lista de Users uno por uno verificando si se busco o no, al verificar un elemento lo guarda//
                {
                    
                    for (int LineasVacias = 0; LineasVacias < 3;)
                    {

                        if (Program.Usuarios[NumerosGuardados + LineasVacias].Buscado == false)
                        {
                            LineasVacias++;
                        }
                        else
                        {
                            for (; LineasVacias > 0;)
                            {
                                using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(FullPath, true))
                                {
                                    file.WriteLine($"{Program.Usuarios[NumerosGuardados].Celular},{Program.Usuarios[NumerosGuardados].Compañia},{Program.Usuarios[NumerosGuardados].Localidad}");
                                }
                                NumerosGuardados++;
                                LineasVacias--;
                            }
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(FullPath, true))
                            {
                                file.WriteLine($"{Program.Usuarios[NumerosGuardados].Celular},{Program.Usuarios[NumerosGuardados].Compañia},{Program.Usuarios[NumerosGuardados].Localidad}");
                            }
                            NumerosGuardados++;
                        }
                    }
                }
                else //Guarda X cantidad de filas de la lista de usuarios en el filtro//
                {
                    for (NumerosGuardados = 0; NumerosGuardados < Buscados; NumerosGuardados++)
                    {
                        using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(FullPath, true))
                        {
                            file.WriteLine($"{Program.Usuarios[NumerosGuardados].Celular},{Program.Usuarios[NumerosGuardados].Compañia},{Program.Usuarios[NumerosGuardados].Localidad}");
                        }
                    }
                }
            }
            catch
            {
                return -1;//Numero usado para indicar un error en el guardado de los numeros en filtro//

            }//Guardado de info//

            try
            {
                Console.WriteLine("\nPor favor no cierre el programa \nSe estan actualizando los datos");

                //Reseteado de la lista//

                if (SeArrastroArchivo) FullPath = User.ArchivoArrastrado[1];
                else FullPath = $@"{Form2.Raiz}\Listas\Lista numeros.txt";
                using (System.IO.FileStream fs = System.IO.File.Create(FullPath)) ;


                //Escibiendo nueva lista//

                int n = User.NumeroDeUsuarios;
                for (int contador = 0; contador < (n - NumerosGuardados); contador++)
                {
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(FullPath, true))
                    {
                        int Write = NumerosGuardados + contador;
                        file.WriteLine(Program.Usuarios[Write].Celular);
                    }
                }
            }
            catch
            {
                return -2;//Numero usado para indicar un error en actualizacion lista de numeros//

            }//Actualizacion de las listas//

            return NumerosGuardados;
        }
        public static bool EliminarPrimerEspacioVacioFiltro(string FullPath)
        {
            try
            {
                if (FullPath == "") FullPath = $@"{Form2.Raiz}\Listas\FiltroUwu.csv";
                List<string> textos = new List<string>();
                string line = "";
                bool EstabaVaciaLaLinea = false;
                using (StreamReader file = new StreamReader(FullPath))
                {
                    if ((line = file.ReadLine()) == "")
                    {
                        EstabaVaciaLaLinea = true;
                        while ((line = file.ReadLine()) != null)
                        {
                            textos.Add(line);
                        }
                    }
                }

                if (EstabaVaciaLaLinea == true)
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(FullPath)) ; //Reseteado el filtro//
                                                                                        //Re-escribiendo Filtro//
                    int n = textos.Count();
                    for (int contador = 0; contador < n; contador++)
                    {
                        using (StreamWriter file2 =
                   new StreamWriter(FullPath, true))
                        {
                            file2.WriteLine(textos[contador]);
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
         
    }
}
