﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Semantics;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Testura.Code.Generate;
using Testura.Code.Generate.ArgumentTypes;
using Testura.Code.Reference;
using Assert = NUnit.Framework.Assert;
using IArgument = Testura.Code.Generate.ArgumentTypes.IArgument;

namespace Testura.Code.Tests.Generate
{
    [TestFixture]
    public class ReferenceTests
    {
        [Test]
        public void Create_WhenCreatingVariableRefernce_ShouldGenerateCorrectCode()
        {
            Assert.AreEqual("myVariable", References.Create(new VariableReference("myVariable")).ToString());
        }

        [Test]
        public void Create_WhenCreatingVariableRefernceWithMethodMember_ShouldGenerateCorrectCode()
        {
            Assert.AreEqual("myVariable.MyMethod()", References.Create(new VariableReference("myVariable", new MethodReference("MyMethod", new List<IArgument>()))).ToString());
        }

        [Test]
        public void Create_WhenCreatingVariableRefernceWithMethodMemberThatHasArgument_ShouldGenerateCorrectCode()
        {
            Assert.AreEqual("myVariable.MyMethod(1,\"test\")", References.Create(new VariableReference("myVariable", new MethodReference("MyMethod", new List<IArgument> { new ValueArgument(1), new ValueArgument("test", ArgumentType.String)}))).ToString());
        }

        [Test]
        public void Create_WhenCreatingVariableRefernceWithFieldMember_ShouldGenerateCorrectCode()
        {
            Assert.AreEqual("myVariable.field", References.Create(new VariableReference("myVariable", new MemberReference("field", MemberReferenceTypes.Field))).ToString());
        }

        [Test]
        public void Create_WhenCreatingVariableRefernceWithPropertyMember_ShouldGenerateCorrectCode()
        {
            Assert.AreEqual("myVariable.Property", References.Create(new VariableReference("myVariable", new MemberReference("Property", MemberReferenceTypes.Property))).ToString());
        }

        [Test]
        public void Create_WhenCreatingVariableRefernceWithChainedMembers_ShouldGenerateCorrectCode()
        {
            Assert.AreEqual("myVariable.MyMethod().MyProperty", References.Create(new VariableReference("myVariable", new MemberReference("MyMethod", MemberReferenceTypes.Method, new MemberReference("MyProperty", MemberReferenceTypes.Property)))).ToString());
        }
    }
}
