using Common.Functions;
using Functions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Functions
{
    [TestFixture]
    class UpdateGridTest
    {
        Mock<IUpdateGrid> updateMock;
        [SetUp]
        public void SetUp()
        {
            updateMock = new Mock<IUpdateGrid>();
        }

    }
}
