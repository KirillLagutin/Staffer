using System;
using System.Collections.Generic;
using System.Linq;
using Staffer.Lib;
using Xunit;

namespace Staffer.Test;

public class DbTest
{
    [Fact]
    public void GetALLStafers_Test()
    {
        var expectedStaffers = new List<Lib.Staffer>
        {
            new ()
            {
                Id = 1, 
                FirstName = "Anonim", 
                LastName = "Anonimus", 
                DateOfBirth = new DateTime(2005, 08, 09),
                Department = "IT",
                Position = "programmer"
            },
            new ()
            {
            Id = 2, 
            FirstName = "Anna", 
            LastName = "Karenina", 
            DateOfBirth = new DateTime(1890, 08, 09),
            Department = "HR",
            Position = "recruiter"
            },
            new ()
            {
                Id = 3, 
                FirstName = "Andrey", 
                LastName = "Starinin", 
                DateOfBirth = new DateTime(1986, 02, 18),
                Department = "Design",
                Position = "designer"
            }
        };
        
        var actualStaffers = DB.GetAllStaffers().ToList();
        
        Assert.Equal(expectedStaffers, actualStaffers);
    }
}