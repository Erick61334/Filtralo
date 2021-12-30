using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Filtramelo
{
    public partial class Form2 : Form
    {
        const float SegundosPorNumero = 4f;
        int ultimohecho = -1;
        public CancellationTokenSource tokenCancel;
        public DialogResult MBresult;
        public Task<bool> MBCerrado;

        //Console.WriteLine($"\nTotal de numeros: {n} \t" + "Tiempo Estimado: " + Leer_Archivo.ConvertToMinutes(Convert.ToInt32(6.22 * n + 13)));

        public Form2()
        {
            InitializeComponent();

            try { User.EliminarPrimerEspacioVacioFiltro(""); } catch { }
            lab_Estado2.Text= "En espera";
            int Error;
            if ((Error = User.LeerInfotxt(""))!= 0)
            {
                
                switch (Error)
                {
                    case 1:
                        MessageBox.Show("Verifica que el archivo ese cerrado antes de ingresarlo al programa");
                        break;

                    case 2:
                        MessageBox.Show("Verifica que el archivo \"Lista de numeros\" exista en la carpeta de Listas del programa");
                        break;
                    case 3:
                        lab_Estado2.Text = "No hay ningun numero para filtrar";
                        break;

                }
            }
            for(int i = 0; i<5; i++)
            {
                //dgv_Usuarios.Rows.Add();
                //dgv_Usuarios.Rows[i].Cells[0].Value = $"{i + 1}";
                User.Filtros.Add(false);
                Tokens.Add(tokenCancel);
            }
        }

        public static int Buscados;
        public static string Raiz = Application.StartupPath;

        public static List<CancellationTokenSource> Tokens = new List<CancellationTokenSource>();


        private async void btn_Reset_Click(int n)
        {
            
            if (Program.Usuarios.Count > 0)
            {
                User.Filtros[n] = true;
                Tokens[n] = new CancellationTokenSource();
                var token = Tokens[n].Token;

                await Task.Run(() =>
                {
                    labEstado2("Buscando");
                    int posicion = 0;
                    int reintenta = 0;
                    try
                    {
                        btn_ResetnBackColor(n + 1, 0);
                        HoraFinalEstimada();
                        IWebDriver driver = new FirefoxDriver();
                        driver.Manage().Window.Minimize();
                        posicion = 0;
                        double num = 0;

                        while (ultimohecho + 1 < User.NumeroDeUsuarios)
                        {
                            try
                            {
                                btn_ResetnBackColor(n + 1, 0);
                                if (reintenta == 0)//primer intento
                                {
                                    ultimohecho++;
                                    posicion = ultimohecho;
                                    Program.Usuarios[posicion].Compañia = "P";
                                    Program.Usuarios[posicion].Localidad = "P";
                                    num = Program.Usuarios[ultimohecho].Celular;
                                    CrearFilaDgv_Usuarios();

                                    dgv_Usuarios.Rows[posicion].Cells[0].Value = $"{posicion + 1}";
                                    dgv_Usuarios.Rows[posicion].Cells[1].Value = num;
                                    dgv_Usuarios.Rows[posicion].Cells[2].Value = "Buscando";
                                    dgv_Usuarios.Rows[posicion].Cells[3].Value = "Buscando";
                                }
                                else// x reintento
                                {

                                    if (reintenta == 4) //Numero maximo de reintentos superado
                                    {
                                        reintenta = 0;
                                        ultimohecho++;
                                        posicion = ultimohecho;
                                        Program.Usuarios[posicion].Compañia = "P";
                                        Program.Usuarios[posicion].Localidad = "P";
                                        num = Program.Usuarios[ultimohecho].Celular;
                                        CrearFilaDgv_Usuarios();

                                        dgv_Usuarios.Rows[posicion].Cells[0].Value = $"{posicion + 1}";
                                        dgv_Usuarios.Rows[posicion].Cells[1].Value = num;
                                        dgv_Usuarios.Rows[posicion].Cells[2].Value = "Buscando";
                                        dgv_Usuarios.Rows[posicion].Cells[3].Value = "Buscando";
                                    }
                                    else dgv_Usuarios.Rows[posicion].Cells[2].Value = $"Reintento: {reintenta}";

                                }

                                btn_ResetnBackColor(n + 1, 0);
                                try
                                {
                                    driver.Url = "https://sns.ift.org.mx:8081/sns-frontend/consulta-numeracion/numeracion-geografica.xhtml";
                                }
                                catch//Si no se puede ir a la url, o el navegdador o la consola fallaron y ambos se reinician
                                {
                                    btn_ResetnBackColor(n + 1, 0);
                                    driver.Quit();
                                    driver = new FirefoxDriver();
                                    driver.Manage().Window.Minimize();
                                    driver.Url = "https://sns.ift.org.mx:8081/sns-frontend/consulta-numeracion/numeracion-geografica.xhtml";
                                }

                                if (num > 1000000000 && num < 10000000000)
                                {
                                    driver.FindElement(By.XPath("//*[@class='ui-inputfield ui-inputtext ui-widget ui-state-default ui-corner-all']")).SendKeys(Convert.ToString(num));
                                    try
                                    {
                                        DarClickSearch(driver, 100, 0);
                                        try//Comprueba si estan disponibles la compañia y la localidad
                                        {
                                            RegistrarCL(driver, 100, posicion, 0);
                                            reintenta = 0;
                                        }
                                        catch//Si fallo en encontrar compañia y localidad
                                        {
                                            try//Comprueba si salio el aviso de "Numero no existe"
                                            {
                                                string a = driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div/form/div[1]/div/div[1]/div/div[1]/div/ul/li/span[1]")).Text.ToString();
                                                Program.Usuarios[posicion].Compañia = "NE";
                                                Program.Usuarios[posicion].Localidad = "NE";
                                                reintenta = 0;
                                            }
                                            catch//Fallo la busqueda, volver a intentar
                                            {
                                                btn_ResetnBackColor(n + 1, 1);
                                                reintenta++;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        btn_ResetnBackColor(n + 1, 1);
                                        reintenta++;
                                    }
                                }
                                else//No es un numero de 10 digitos por lo que sin buscar, se sabe que no existe
                                {
                                    Program.Usuarios[posicion].Compañia = "NE";
                                    Program.Usuarios[posicion].Localidad = "NE";
                                    reintenta = 0;

                                }
                                dgv_Usuarios.Rows[posicion].Cells[0].Value = $"{posicion + 1}";
                                dgv_Usuarios.Rows[posicion].Cells[1].Value = num;
                                dgv_Usuarios.Rows[posicion].Cells[2].Value = Program.Usuarios[posicion].Compañia;
                                dgv_Usuarios.Rows[posicion].Cells[3].Value = Program.Usuarios[posicion].Localidad;
                                labEstado2($"Buscando {User.NumeroDeUsuarios - ultimohecho} restantes");
                            }
                            catch
                            {
                                dgv_Usuarios.Rows[posicion].Cells[0].Value = $"{posicion + 1}";
                                dgv_Usuarios.Rows[posicion].Cells[1].Value = Program.Usuarios[ultimohecho].Celular;
                                dgv_Usuarios.Rows[posicion].Cells[2].Value = Program.Usuarios[posicion].Compañia;
                                dgv_Usuarios.Rows[posicion].Cells[3].Value = Program.Usuarios[posicion].Localidad;
                                labEstado2($"Buscando {User.NumeroDeUsuarios - ultimohecho + 1} restantes");
                                reintenta++;
                                btn_ResetnBackColor(n + 1, 1);
                                Thread.Sleep(500);
                            }
                            if (token.IsCancellationRequested) break;

                        }

                        try
                        {
                            driver.Quit();
                        }
                        catch
                        {

                        }
                        User.Filtros[n] = false;
                        btn_ResetnBackColor(n + 1, 2);

                        if (User.Filtros[0] == false && User.Filtros[1] == false && User.Filtros[2] == false && User.Filtros[3] == false && User.Filtros[4] == false)
                        {
                            if (token.IsCancellationRequested)//Se apreto el boton de guardar y salir(y Se guardo en GuardarYSalir()) ó Se le dio click a salir sin guardar//
                            {
                                MessageBox.Show("Gracias por confiar en Erick Industries (◉⩊◉) bye bye");
                                Application.Exit();
                            }
                            if (posicion + 1 >= User.NumeroDeUsuarios)//Se completo la lista de numeros a buscar//
                            {
                                User.Filtros[n] = true;
                                labEstado2("Guardando");
                                User.GuardarInfo(User.NumeroDeUsuarios);
                                labEstado2("Lista completa guardada (◉⩊◉), cerrando ventanas");
                                MessageBox.Show("Gracias por confiar en Erick Industries (◉⩊◉) Bye Bye");
                                Application.Exit();
                            }
                        }
                    }
                    catch
                    {
                    }
                }, token);
            }
            else
            {
                await Task.Run(() =>
                { 
                    int MiliIntervalo = 333;
                    labEstado2("NO HAY NINGUN NUMERO PARA FILTRAR");
                    btn_ResetnBackColor(n + 1, 1);
                    Thread.Sleep(MiliIntervalo);
                    labEstado2("No hay ningun numero para filtrar");
                    btn_ResetnBackColor(n + 1, 2);
                    Thread.Sleep(MiliIntervalo);
                    labEstado2("NO HAY NINGUN NUMERO PARA FILTRAR");
                    btn_ResetnBackColor(n + 1, 1);
                    Thread.Sleep(MiliIntervalo);
                    labEstado2("No hay ningun numero para filtrar");
                    btn_ResetnBackColor(n + 1, 2);
                    Thread.Sleep(MiliIntervalo);
                    labEstado2("NO HAY NINGUN NUMERO PARA FILTRAR");
                    btn_ResetnBackColor(n + 1, 1);
                    Thread.Sleep(MiliIntervalo);
                    labEstado2("No hay ningun numero para filtrar");
                    btn_ResetnBackColor(n + 1, 2);
                });
            }
        }
        private void btn_Reset1_Click(object sender, EventArgs e)
        {
            btn_Reset_Click(0);
        }
        private void btn_Reset2_Click(object sender, EventArgs e)
        {
            btn_Reset_Click(1);
        }
        private void btn_Reset3_Click(object sender, EventArgs e)
        {
            btn_Reset_Click(2);
        }
        private void btn_Reset4_Click(object sender, EventArgs e)
        {
            btn_Reset_Click(3);
        }
        private void btn_Reset5_Click(object sender, EventArgs e)
        {
            btn_Reset_Click(4);
        }

        private async void Form2_DragDrop(object sender, DragEventArgs e)
        {
            await Task.Run(() =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                    foreach (string file in files)
                    {

                        if (User.EliminarPrimerEspacioVacioFiltro(file) == true)
                        {

                            int Error;
                            if ((Error = User.LeerInfotxt(file)) == 0)
                            {
                                labEstado2($"{User.NumeroDeUsuarios} numeros en espera");
                                User.SeArrastroArchivo = true;
                            }
                            else
                            {
                                switch (Error)
                                {
                                    case 1:
                                        MessageBox.Show("Verifica que el archivo ese cerrado antes de ingresarlo al programa");
                                        break;

                                    case 2:
                                        MessageBox.Show("Verifica que el archivo \"Lista de numeros\" exista en la carpeta de Listas del programa");
                                        break;
                                    case 3:
                                        labEstado2($"No se leyo ningun numero extra, aun asi hay {User.NumeroDeUsuarios} numeros en espera");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Verifica que el archivo ese cerrado antes de ingresarlo al programa");
                        }

                        int SegundosEstimados = Convert.ToInt32((SegundosPorNumero* User.NumeroDeUsuarios) / 5 + 13);
                        lab_HFE.Invoke((MethodInvoker)(() => lab_HFE.Text = $"{SegundosEstimados/3600}h {(SegundosEstimados%3600)/60}m (5 Filtros activos)"));
                    }
                }
            });
        }
        private void Form2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }
        private async void btn_SalirSinGuardar_Click(object sender, EventArgs e)
        {
            lab_Estado2.Text = "Cerrando...";
            await Task.Run(() =>
            {
                if (User.Filtros[0] == true)
                {
                    Tokens[0].Cancel();
                }
                if (User.Filtros[1] == true)
                {
                    Tokens[1].Cancel();
                }
                if (User.Filtros[2] == true)
                {
                    Tokens[2].Cancel();
                }
                if (User.Filtros[3] == true)
                {
                    Tokens[3].Cancel();
                }
                if (User.Filtros[4] == true)
                {
                    Tokens[4].Cancel();
                }
                if (User.Filtros[0] == false && User.Filtros[1] == false && User.Filtros[2] == false && User.Filtros[3] == false && User.Filtros[4] == false)
                {
                    Application.Exit();                
                }
            });
            Thread.Sleep(10000);
        }
        private async void btn_SaveAndQui_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (User.Filtros[0] == true)
                {
                    Tokens[0].Cancel();
                }
                if (User.Filtros[1] == true)
                {
                    Tokens[1].Cancel();
                }
                if (User.Filtros[2] == true)
                {
                    Tokens[2].Cancel();
                }
                if (User.Filtros[3] == true)
                {
                    Tokens[3].Cancel();
                }
                if (User.Filtros[4] == true)
                {
                    Tokens[4].Cancel();
                }

                labEstado2("Guardando");
                Buscados = User.GuardarInfo(0);
                labEstado2("Guardado (◉⩊◉), cerrando ventanas");

                //if(Buscados>-1 && Buscados < 5) { Buscados = 5; }
                if (Buscados == -1)
                {
                    MBresult = MessageBox.Show("Algo salio mal al guardar los datos");
                }
                else
                {
                    if (Buscados == -2)
                    {
                        MBresult = MessageBox.Show("Algo salio mal al actualizar las listas");
                    }
                    else
                    {
                        MBresult = DialogResult.OK;
                    }
                }
                
                
            });

            await Task.Run(() =>
            {
                switch (MBresult)
                {
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        MBCerrado = Definir(true);
                        break;

                    case DialogResult.No:
                    case DialogResult.Abort:
                        MBCerrado = Definir(false);
                        break;

                    default:
                        MBCerrado = Definir(true);
                        break;
                }
            });

            await MBCerrado;
        }
        void labEstado2(string texto)
        {
            lab_Estado2.Invoke((MethodInvoker)(() => lab_Estado2.Text = texto));//Detiene momentaneamente el hilo que la llama y actualiza el label//
        }
        async void btn_ResetnBackColor(int boton, int color)//0 = Verde, 1 = Rojo, 2 = Light Gray//
        {
            await Task.Run(() =>
            {
                switch (boton)
                {
                    case 1:
                        switch (color)
                        {
                            case 0:

                                btn_Reset1.BackColor = Color.Green;
                                break;

                            case 1:
                                btn_Reset1.BackColor = Color.Red;
                                break;

                            case 2:
                                btn_Reset1.BackColor = Color.LightGray;
                                break;
                        }
                        break;

                    case 2:
                        switch (color)
                        {
                            case 0:

                                btn_Reset2.BackColor = Color.Green;
                                break;

                            case 1:
                                btn_Reset2.BackColor = Color.Red;
                                break;

                            case 2:
                                btn_Reset2.BackColor = Color.LightGray;
                                break;
                        }
                        break;

                    case 3:
                        switch (color)
                        {
                            case 0:

                                btn_Reset3.BackColor = Color.Green;
                                break;

                            case 1:
                                btn_Reset3.BackColor = Color.Red;
                                break;

                            case 2:
                                btn_Reset3.BackColor = Color.LightGray;
                                break;
                        }
                        break;

                    case 4:
                        switch (color)
                        {
                            case 0:

                                btn_Reset4.BackColor = Color.Green;
                                break;

                            case 1:
                                btn_Reset4.BackColor = Color.Red;
                                break;

                            case 2:
                                btn_Reset4.BackColor = Color.LightGray;
                                break;
                        }
                        break;

                    case 5:
                        switch (color)
                        {
                            case 0:

                                btn_Reset5.BackColor = Color.Green;
                                break;

                            case 1:
                                btn_Reset5.BackColor = Color.Red;
                                break;

                            case 2:
                                btn_Reset5.BackColor = Color.LightGray;
                                break;
                        }
                        break;
                }
            });

            
        }
        void CrearFilaDgv_Usuarios()
        {
            dgv_Usuarios.Invoke((MethodInvoker)(() => dgv_Usuarios.Rows.Add()));//Detiene momentaneamente el hilo que la llama y actualiza el label//
        }
        void DarClickSearch(IWebDriver driver, int intervalo, int contador)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement Search = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='FORM_myform:BTN_publicSearch']")));
                Search.Click();
            }
            catch
            {
                contador++;
                Thread.Sleep(intervalo);
                if (contador < 6) DarClickSearch(driver, intervalo, contador);
            }

        }
        void RegistrarCL(IWebDriver driver, int intervalo, int posicion, int contador)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                _ = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='FORM_myform:TBL_numberInfoTable_content']/div[7]/div[2]")));
                Program.Usuarios[posicion].Compañia = driver.FindElement(By.XPath("/ html / body / div[2] / div / div[4] / div / form / div[3] / div / div / div[2] / div[7] / div[2]")).Text.ToString();
                Program.Usuarios[posicion].Localidad = driver.FindElement(By.XPath("//*[@id='FORM_myform:TBL_numberInfoTable_content']/div[3]/div[2]")).Text.ToString();
                Program.Usuarios[posicion].Buscado = true;
            }
            catch
            {
                contador++;
                Thread.Sleep(intervalo);
                if (contador < 6) RegistrarCL(driver, intervalo, posicion, contador);
            }
           
        }
        private async void HoraFinalEstimada()
        {
            await Task.Run(() =>
            {
                int NumFiltros = User.Filtros.Count();
                int FiltrosActivos = 0;
                for(int i = 0; i<NumFiltros; i++)
                {
                    if (User.Filtros[i] == true) FiltrosActivos++;
                }
                double TiempoEstimadoSeg = Convert.ToDouble(SegundosPorNumero*(User.NumeroDeUsuarios-ultimohecho+1)/FiltrosActivos+13);

                var NowTime = DateTime.Now;
                var FinalTime = NowTime.AddSeconds(TiempoEstimadoSeg);

                //13 seg iniciar navegador, 3 segundos busqueda por numero

                lab_TE.Invoke((MethodInvoker)(() => lab_TE.Text = "Hora final estimada:"));
                lab_HFE.Invoke((MethodInvoker)(() => lab_HFE.Text = FinalTime.ToString()));
            });
        }
        async Task<bool> Definir (bool b)
        {
            if (b == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
