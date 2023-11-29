// Avaliação individual
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa(string _nome, DateTime _dataDeNascimento, string _cpf)
    {
        Nome = _nome;
        DataDeNascimento = _dataDeNascimento;
        CPF = _cpf;
    }

}

class Medico : Pessoa
{
    public string CRM { get; set; }

    public Medico(string _nome, DateTime _dataDeNascimento, string _cpf, string _crm) : base(_nome, _dataDeNascimento, _cpf)
    {
        CRM = _crm;
    }
}

class Paciente : Pessoa
{
    public string Sexo { get; set; }
    public string Sintomas { get; set; }

    public Paciente(string _nome, DateTime _dataDeNascimento, string _cpf, string _sexo, string _sintomas) : base(_nome, _dataDeNascimento, _cpf)
    {
        Sexo = _sexo;
        Sintomas = _sintomas;
    }
}

class Gerenciamento
{

    static List<Medico> medicos = new List<Medico>();
    static List<Paciente> pacientes = new List<Paciente>();

    static void Main()
    {

        int opcao;

        do
        {
            Console.WriteLine("1 - Incluir paciente");
            Console.WriteLine("2 - Incluir médico");
            Console.WriteLine("3 - Exibir relatórios");
            Console.WriteLine("4 - Sair");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1){
                IncluirPaciente();
            } else if (opcao == 2){
                IncluirMedico();
            } else if (opcao == 3) {
                ExibirRelatorios();
            } else if (opcao == 4){
                Console.WriteLine("Programa Encerrado!");
            }
        } while (opcao != 4);
    }

    static void IncluirPaciente()
    {
        Console.WriteLine("Nome do Paciente: ");
        string _nome = Console.ReadLine();

        Console.WriteLine("Data de Nascimento no formato ano/mes/dia: ");
        DateTime _dataDeNascimento = DateTime.Parse(Console.ReadLine());

        Console.Write("CPF do paciente: ");
        string _cpf = Console.ReadLine();

        if (pacientes.Any(p => p.CPF == _cpf))
        {
            Console.WriteLine("CPF pertence a outro paciente.");
            return;
        }

        Console.WriteLine("Sexo do paciente (M ou F): ");
        string _sexo = Console.ReadLine();

        Console.WriteLine("Sintomas do paciente: ");
        string _sintomas = Console.ReadLine();

        Paciente paciente = new Paciente(_nome, _dataDeNascimento, _cpf, _sexo, _sintomas);
        pacientes.Add(paciente);

        Console.WriteLine("Paciente cadastrado com sucesso!!\n");
    }

    static void IncluirMedico()
    {

        Console.WriteLine("Nome do Médico: ");
        string _nome = Console.ReadLine();

        Console.WriteLine("Data de Nascimento o formato ano/mes/dia: ");
        DateTime _dataDeNascimento = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("CPF do médico: ");
        string _cpf = Console.ReadLine();
        if (medicos.Any(m => m.CPF == _cpf))
        {
            Console.WriteLine("CPF pertence a outro médico");
            return;
        }

        Console.WriteLine("CRM do médico: ");
        string _crm = Console.ReadLine();
        if (medicos.Any(m => m.CRM == _crm))
        {
            Console.WriteLine("CRM pertence a outro médico");
            return;
        }

        Medico medico = new Medico(_nome, _dataDeNascimento, _cpf, _crm);
        medicos.Add(medico);

        Console.WriteLine("Médico adicionado com sucesso!!");

    }

    static void ExibirRelatorios()
    {   
        int opcao;
        
        do{
            Console.WriteLine("Escolha o relatório:");
            Console.WriteLine("1 - Médicos com idade entre dois valores");
            Console.WriteLine("2 - Pacientes com idade entre dois valores");
            Console.WriteLine("3 - Pacientes do sexo informado pelo usuário");
            Console.WriteLine("4 - Pacientes em ordem alfabética");
            Console.WriteLine("5 - Pacientes cujos sintomas contenham texto informado pelo usuário");
            Console.WriteLine("6 - Médicos e Pacientes aniversariantes do mês informado");
            Console.WriteLine("7 - Sair");
    
            opcao = int.Parse(Console.ReadLine());
    
            if (opcao == 1){
                    RelatorioMedicosPorIdade();
                }else if (opcao == 2){
                    RelatorioPacientesPorIdade();
                }else if (opcao == 3){
                    RelatorioPacientesPorSexo();
                }else if (opcao == 4) {
                    RelatorioPacientesOrdemAlfabetica();
                } else if (opcao == 5) {
                    RelatorioPacientesPorSintomas();
                }else if (opcao == 6)  {
                    RelatorioAniversariantesDoMes();
                }else if (opcao == 7){
                Console.WriteLine("Programa Encerrado!");
                }
        } while (opcao != 7);
        
    }

    static void RelatorioMedicosPorIdade()
    {
        Console.WriteLine("Informe a idade mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe a idade máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine());

        var medicosFiltrados = medicos.Where(m => (DateTime.Now.Year - m.DataDeNascimento.Year) >= idadeMinima && (DateTime.Now.Year - m.DataDeNascimento.Year) <= idadeMaxima);

        Console.WriteLine("Médicos com idade entre " + idadeMinima + " e " + idadeMaxima + " anos:");
        foreach (var medico in medicosFiltrados)
        {
            Console.WriteLine($"Nome: {medico.Nome}, Idade: {DateTime.Now.Year - medico.DataDeNascimento.Year} anos");
        }
    }

    static void RelatorioPacientesPorIdade()
    {
        Console.WriteLine("Informe a idade mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe a idade máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine());

        var pacientesFiltrados = pacientes.Where(p => (DateTime.Now.Year - p.DataDeNascimento.Year) >= idadeMinima && (DateTime.Now.Year - p.DataDeNascimento.Year) <= idadeMaxima);

        Console.WriteLine("Pacientes com idade entre " + idadeMinima + " e " + idadeMaxima + " anos:");
        foreach (var paciente in pacientesFiltrados)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Idade: {DateTime.Now.Year - paciente.DataDeNascimento.Year} anos");
        }
    }

    static void RelatorioPacientesPorSexo()
    {
        Console.WriteLine("Informe o sexo (M ou F): ");
        string sexo = Console.ReadLine().ToUpper();

        var pacientesFiltrados = pacientes.Where(p => p.Sexo.ToUpper() == sexo);

        Console.WriteLine("Pacientes do sexo " + sexo + ":");
        foreach (var paciente in pacientesFiltrados)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Sexo: {paciente.Sexo}");
        }
    }

    static void RelatorioPacientesOrdemAlfabetica()
    {
        var pacientesOrdenados = pacientes.OrderBy(p => p.Nome);

        Console.WriteLine("Pacientes em ordem alfabética:");
        foreach (var paciente in pacientesOrdenados)
        {
            Console.WriteLine($"Nome: {paciente.Nome}");
        }
    }

    static void RelatorioPacientesPorSintomas()
    {
        Console.WriteLine("Informe o texto dos sintomas: ");
        string textoSintomas = Console.ReadLine();

        var pacientesFiltrados = pacientes.Where(p => p.Sintomas.Contains(textoSintomas));

        Console.WriteLine($"Pacientes cujos sintomas contenham \"{textoSintomas}\":");
        foreach (var paciente in pacientesFiltrados)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Sintomas: {paciente.Sintomas}");
        }
    }

    static void RelatorioAniversariantesDoMes()
    {
        Console.WriteLine("Informe o mês (1 a 12): ");
        int mes = int.Parse(Console.ReadLine());

        var aniversariantes = medicos.Select(m => (Pessoa)m).Where(p => p.DataDeNascimento.Month == mes).Concat(pacientes.Select(p => (Pessoa)p).Where(p => p.DataDeNascimento.Month == mes));

        Console.WriteLine($"Aniversariantes do mês {mes}:");
        foreach (var pessoa in aniversariantes)
        {
            Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataDeNascimento.ToShortDateString()}");
        }
    }
}
