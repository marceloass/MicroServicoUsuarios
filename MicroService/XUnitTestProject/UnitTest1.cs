using System;
using Xunit;
using JuntosSeguros.Controllers;
using JuntosSeguros.Database.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        UserController control = new UserController();

        [Fact]
        public void TestCreate()
        {
            User user = new User();
            user.Name = "Geremias";
            var result = control.Post(user);
            Assert.True(result);
            
        }
        [Fact]
        public void TestEdit()
        {
            User user = new User();
            user.Name = "Matheus";
            user.Email = "MeContrata@hotmail.com";
            user.Password = "1234";
            var result = control.Put(3,user);
            Assert.True(result);
        }
        [Fact]
        public void TestDelete()
        {
            var result = control.Delete(5);
            Assert.True(result);
        }
        [Fact]
        public void TestList()
        {
            List<User> listUsers = control.Get().ToList();
            Assert.NotNull(listUsers);
        }
    }
}
