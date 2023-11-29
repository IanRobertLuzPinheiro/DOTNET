// Avaliação individual
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class Medico{
    public string Nome {get;set;}
    public DateTime DataDeNascimento {get;set;}
    public string CRM {get;set;}
    public string CPF {get;set;}
    
    public Medico(string _nome, DateTime _dataDeNascimento, string _crm, string _cpf){
        Nome = _nome;
        DataDeNascimento = _dataDeNascimento;
        CRM = _crm;
        CPF = _cpf;
    }
    
}

class Paciente{
    public string Nome {get; set;}
    public DateTime DataDeNascimento{get; set;}
    public string CPF {get; set;}
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

