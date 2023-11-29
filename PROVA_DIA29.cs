// Avaliação individual
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class Pessoa{
    public string Nome {get;set;}
    public DateTime DataDeNascimento {get;set;}
    public string CPF {get;set;}
    
    public Medico(string _nome, DateTime _dataDeNascimento, string _cpf){
        Nome = _nome;
        DataDeNascimento = _dataDeNascimento;
        CPF = ValidarCPF(_cpf);
    }
    
    private string ValidarCPF(string _cpf){
        return _cpf;
    }
}

}
class Medico:Pessoa{
    public string CRM {get;set;}

    public Medico(string _nome, DateTime _dataDeNascimento, string _cpf, string _crm):base(_nome,_dataDeNascimento,_cpf){
        CRM = ValidarCRM(_crm);
    }
    
    private string ValidarCRM(string _crm){
        return _crm;
    }
    
}

class Paciente:Pessoa{
    public string Sexo {get; set;}
    public string Sintomas {get;set;}
    
     public Paciente(string _nome, DateTime _dataDeNascimento, string _cpf, string _sexo, string _sintomas):base(_nome,_dataDeNascimento,_cpf){
        Sexo = _sexo;
        Sintomas = _sintomas;
    }
}

class Gerenciamento{
    
    static List<Medico> medicos = new List<Medico>();
    static List<Paciente> pacientes = new List<Paciente>();
    
    static void Main() {
      
      int opcao;
      
        do
        {
            Console.WriteLine("1 - Incluir paciente");
            Console.WriteLine("2 - Incluir médico ;
            Console.WriteLine("3 - Exibir relatórios");
            Console.WriteLine("4 - Sair");
            
            opcao = int.Parse(Console.ReadLine());
            
             if(opcao == 1){
                
                IncluirPaciente()
                
            }else if(opcao == 2){
                
                IncluirMedico()
                
            }else if(opcao == 3){
                
                ExibirRelatorios()
                
            }else if(opcao == 4){
                
                Console.WriteLine("Programa Encerrado!");
            }
            
        }while(opcao!=4);
    }
    
    static void IncluirPaciente(){
        Console.WriteLine("Nome do Paciente: ");
        string _nome = Console.ReadLine(;
        
        Console.WriteLine("Data de Nacimento: ");
        DateTime _dataDeNascimento= DateTime.Parse(Console.ReadLine());
        
        Console.Write("CPF do paciente: ");
        string _cpf = Console.ReadLine(;
        
        if(pacientes.Any(p => p.CPF == cpf)){
            Console.WriteLine("CPF pertence a outro paciente.");
            return;
        }
        
        Console.WriteLine("Sexo do paciente: ");
        string _sexo = Console.ReadLine();
        
        Console.WriteLine("Sintomas do paciente: ");
        string _sintomas = Console.ReadLine();
        
        Paciente paciente = new Paciente(_nome, _dataDeNascimento, _cpf, _sexo, _sintomas);
        pacientes.Add(paciente);
        
        Console.WriteLine("Paciente cadastrado com sucesso!!\n");
    }
    
    static void IncluirMedico(){
        
        Console.WriteLine("Nome do Médico: ");
        string _nome = Console.ReadLine(;
        
        Console.WriteLine("Data de nacimento: ");
        DateTime _dataDeNascimento = DateTime.Parse(Console.ReadLine());
        
        Console.WriteLine("CPF do médico: ");
        string _cpf = Console.ReadLine();
        if(medicos.Any(m => m.CPF == _cpf){
            Console.WriteLine("CPF pertence a outro médico");
            return;
        }
        
        Console.WriteLine("CRM do médico: ");
        string _crm = Console.ReadLine();
        if(medicos.Any(m => m.CRM= _crm
            Console.WriteLine("CRM pertence a outro médico");
            return;
        }
        
        Medico medico = new Medico(_nome, _dataDeNascimento, _cpf, _crm);
        medicos.Add(medico);
        
        Console.WriteLine("Medico adicionado com sucesso!!");
        
    }
}
