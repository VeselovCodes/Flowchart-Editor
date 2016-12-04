using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowchartEditorMVP.Model;

namespace FlowchartEditorMVP.Tests
{
    [TestClass]
    public class OrientedGraphTests
    {
        [TestMethod]
        public void countNodes_returns_20()
        {
            int expectedNumberOfNodes = 20;
            OrientedGraph graph = new OrientedGraph(20);
            int actualNumberOfNodes = graph.countNodes();
            Assert.AreEqual(expectedNumberOfNodes, actualNumberOfNodes);
        }

        [TestMethod]
        public void countEdges_returns_0()
        {
            int expectedNumberOfEdges = 0;
            OrientedGraph graph = new OrientedGraph(5);
            int actualNumberOfEdges = graph.countEdges();
            Assert.AreEqual(expectedNumberOfEdges, actualNumberOfEdges);
        }
    }
}
