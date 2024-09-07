﻿using JornadaMilhas.ListaDeExercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.ListaDeExercicios;

public class MusicaTest
{
    [Fact]
    public void TestandoNomeDaMusica()
    {
        // Arrange
        string nome = "Nome da Música";

        // Act
        var musica = new Musica(nome);

        
        // Assert
        Assert.Equal("Nome da Música", musica.Nome);
    }

    [Fact]
    public void TestandoIdentificadorDaMusica()
    {
        // Arrange
        string nome = "Nome da Música";
        int id = 69;


        // Act
        var musica = new Musica(nome)
        {
            Id = id
        };

        
        // Assert
        Assert.Equal(id, musica.Id);
    }

    [Fact]
    public void TestandoToString()
    {
        // Arrange
        string nome = "Nome da Música";
        int id = 69;
        var musica = new Musica(nome)
        {
            Id = id
        };
        string expectedString = $"Id: {id} Nome: {nome}";

        // Act
        string resultado = musica.ToString();


        // Assert
        Assert.Equal(expectedString, resultado);
    } 
}
