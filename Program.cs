using System;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MestradoDataBase
{
    class Program
    {
        static void Main(string[] args = null)
        {
            Console.WriteLine("Bem vindo ao Banco de dados da Rose, o que gostaria de fazer?");
            Console.WriteLine("1 - Para adicionar");
            Console.WriteLine("2 - Para Consultar");
            float numeroSelecaoMenu = float.Parse(Console.ReadLine());
            if (numeroSelecaoMenu == 1)
            {
                CadastroDoRecordatorio();
            }
            else
            {
                ConsultaRecordatorios();
            }

        }

        static void CadastroDoRecordatorio()
        {
            var recordatorio = new Recordatorio();
            Console.WriteLine("Insira o numero do Paciente:");
            recordatorio.numeroDoPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o dia do recordatorio:");
            recordatorio.dia = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor das Proteinas:");
            recordatorio.proteinas = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor dos Lipidios:");
            recordatorio.lipidios = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor dos Carboidratos:");
            recordatorio.carboidratos = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor das Calorias:");
            recordatorio.calorias = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da AG Monoinsat:");
            recordatorio.agMonoinsat = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da AG Poliinsat:");
            recordatorio.agPoliinsat = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da AG Saturada:");
            recordatorio.agSaturada = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da AG Trans:");
            recordatorio.agTrans = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor do Colesterol:");
            recordatorio.colesterol = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor das Fibras:");
            recordatorio.fibras = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor do Calcio:");
            recordatorio.calcio = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor do Ferro:");
            recordatorio.ferro = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da Vit B12:");
            recordatorio.vitB12 = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da Vit C:");
            recordatorio.vitC = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor da Vit E:");
            recordatorio.vitE = float.Parse(Console.ReadLine());

            Console.WriteLine("deseja salvar?");
            Console.WriteLine("1- Para Sim");
            Console.WriteLine("2- Para Não");
            float opcaoDeSalvar = float.Parse(Console.ReadLine());

            if (opcaoDeSalvar == 1)
            {

                const string connectionString = "Server=localhost,1433;Database=MestradoDataBase;User ID=sa;Password=M@yer0620;TrustServerCertificate=True";


                var insertDataFromRecordatorio = @"INSERT INTO 
                [RECORDATORIO] 
            VALUES 
                (@numeroDoPaciente, 
                @dia, 
                @proteinas, 
                @lipidios, 
                @carboidratos,
                @calorias,
                @agMonoinsat,
                @agPoliinsat,
                @agSaturada,
                @agTrans,
                @colesterol,
                @fibras,
                @calcio,
                @ferro,
                @vitB12,
                @vitC,
                @vitE)";

                using (var connection = new SqlConnection(connectionString))
                {
                    var affectedRows = connection.Execute(insertDataFromRecordatorio, new
                    {
                        recordatorio.numeroDoPaciente,
                        recordatorio.dia,
                        recordatorio.proteinas,
                        recordatorio.lipidios,
                        recordatorio.carboidratos,
                        recordatorio.calorias,
                        recordatorio.agMonoinsat,
                        recordatorio.agPoliinsat,
                        recordatorio.agSaturada,
                        recordatorio.agTrans,
                        recordatorio.colesterol,
                        recordatorio.fibras,
                        recordatorio.calcio,
                        recordatorio.ferro,
                        recordatorio.vitB12,
                        recordatorio.vitC,
                        recordatorio.vitE
                    });
                    Console.WriteLine($"{affectedRows} linhas inseridas");
                }
            }
            else
            {
                Main();
            }



        }

        static void ConsultaRecordatorios()
        {
            const string connectionString = "Server=localhost,1433;Database=MestradoDataBase;User ID=sa;Password=M@yer0620;TrustServerCertificate=True";
            
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Nº do Paciente - Dia - Proteinas - Lipidios - Carboidratos - Calorias - AG Mono - AG Poli - AG Sat - AG Trans - Colesterol - Fibras - Calcio - Fero - Vit B12 - Vit C - Vit E");
                var recordatorios = connection.Query<Recordatorio>("SELECT * FROM [RECORDATORIO]");
                foreach (var item in recordatorios)
                {                
                Console.WriteLine(@$"----- {item.numeroDoPaciente} --------- {item.dia} ---- {item.proteinas} ------ {item.lipidios} ------- {item.carboidratos} ------ {item.calorias} ------ {item.agMonoinsat} ------ {item.agPoliinsat} ----- {item.agSaturada} ----- {item.agTrans} ------ {item.colesterol} ----- {item.fibras} --- {item.calcio} -- {item.ferro} -- {item.vitB12} --- {item.vitC} --- {item.vitE}");
                }

            }

        }

    }
}