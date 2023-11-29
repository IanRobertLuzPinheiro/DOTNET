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
        CRM = Validar
    }
    
}

class Paciente{
    public string Sexo {get; set;}
    public string Sintomas {get;set;}
    
     public Paciente(string _nome, DateTime _dataDeNascimento, string cpf, string _sexo, string _sintomas){
        Nome = _nome;
        DataDeNascimento = _dataDeNascimento;
        CPF = _cpf;
        Sexo = _sexo;
        Sintomas = _sintomas;
    }
}

class Gerenciamento{
    static void Main() {
      
      int opcao;
      
    do
    {
        Console.WriteLine("1 - ");
        Console.WriteLine("2 - ");
        Console.WriteLine("3 - ");
        Console.WriteLine("4 - ");
        Console.WriteLine("5 - ");
        Console.WriteLine("6 - ");
        Console.WriteLine("7 - ");
        Console.WriteLine("8 - ");
        Console.WriteLine("9 - Sair");
        
        opcao = int.Parse(Console.ReadLine());
        
         if(opcao == 1){
            

            
        }else if(opcao == 2){
            

            
        }else if(opcao == 3){
            

            
        }else if(opcao == 4){

            
        }else if(opcao == 5){
            

            
        }
        else if(opcao == 6){
            

            
        }else if(opcao == 7){
            

            
        }else if(opcao == 8){
            

            
        }else if(opcao == 9){
            
            Console.WriteLine("Programa Encerrado!");
        }
        
    }while(opcao!=9);
}
