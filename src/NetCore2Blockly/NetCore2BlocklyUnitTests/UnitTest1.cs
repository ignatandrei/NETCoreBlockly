using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using NetCore2Blockly;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetCore2BlocklyUnitTests
{
    public class ActionListExtensionsUnitTests
    {
        //BindingSource _bindingSource = new BindingSource("1", "s", false, false);
        //Dictionary<string, (Type type, BindingSource bs)> _paramsDict = new Dictionary<string, (Type type, BindingSource bs)>();
        //Dictionary<string, (Type type, BindingSource bs)> _secondParamsDict = new Dictionary<string, (Type type, BindingSource bs)>();


        //[Fact]
        //public void Should_return_an_ActionList_return_type_and_Blockly_type_association()
        //{
        //    var actionInfo = new Mock<ActionInfo>();
        //    AddOneString(_paramsDict);
        //    actionInfo.SetupGet(x => x.Params).Returns(_paramsDict);
        //    List<ActionInfo> actionList = new List<ActionInfo> { actionInfo.Object };

        //    var v = actionList.GetAllTypesWithNullBlocklyType();

        //    Assert.True(v.Length == 1);
            
        //}

        //[Fact]
        //public void Should_return_two_ActionList_return_types_and_Blockly_type_associations()
        //{
        //    var actionInfo = new Mock<ActionInfo>();
        //    AddTwoDistinctParameters(_paramsDict);
        //    actionInfo.SetupGet(x => x.Params).Returns(_paramsDict);
        //    List<ActionInfo> actionList = new List<ActionInfo> { actionInfo.Object };

        //    var v = actionList.GetAllTypesWithNullBlocklyType();

        //    Assert.True(v.Length == 2);

        //}

        //[Fact]
        //public void Should_return_two_distinct_ActionList_return_types_and_Blockly_type_associations()
        //{
        //    var actionInfo = new Mock<ActionInfo>();
        //    AddThreeParameters(_paramsDict);
        //    actionInfo.SetupGet(x => x.Params).Returns(_paramsDict);

        //    List<ActionInfo> actionList = new List<ActionInfo> { actionInfo.Object };

        //    var v = actionList.GetAllTypesWithNullBlocklyType();

        //    Assert.True(v.Length == 2);

        //}

        //[Fact]
        //public void Should_return_two_distinct_ActionList_return_types_and_Blockly_type_associations_for_two_Actions()
        //{
        //    var actionInfo1 = new Mock<ActionInfo>();
        //    AddOneString(_paramsDict);
        //    actionInfo1.SetupGet(x => x.Params).Returns(_paramsDict);

        //    var actionInfo2 = new Mock<ActionInfo>();
        //    AddOneLong(_secondParamsDict);
        //    actionInfo2.SetupGet(x => x.Params).Returns(_secondParamsDict);
        //    List<ActionInfo> actionList = new List<ActionInfo> { actionInfo1.Object, actionInfo2.Object  };

        //    var v = actionList.GetAllTypesWithNullBlocklyType();
            
            
        //    Assert.True(v.Length == 2 );

        //}

        //[Fact]
        //public void Should_return_one_ActionList_return_type_and_Blockly_type_association_for_two_Actions()
        //{
        //    var actionInfo1 = new Mock<ActionInfo>();
        //    AddOneString(_paramsDict);
        //    actionInfo1.SetupGet(x => x.Params).Returns(_paramsDict);

        //    var actionInfo2 = new Mock<ActionInfo>();
        //    AddAnotherString(_secondParamsDict);
        //    actionInfo2.SetupGet(x => x.Params).Returns(_secondParamsDict);

        //    List<ActionInfo> actionList = new List<ActionInfo> { actionInfo1.Object, actionInfo2.Object };

        //    var v = actionList.GetAllTypesWithNullBlocklyType();


        //    Assert.True(v.Length == 1 );
        //}

        //void AddOneString(Dictionary<string, (Type type, BindingSource bs)> dictionary)
        //{
        //    dictionary.Add("A_string", (typeof(String), _bindingSource));
        //}

        //void AddAnotherString(Dictionary<string, (Type type, BindingSource bs)> dictionary)
        //{
        //    dictionary.Add("Another_string", (typeof(String), _bindingSource));
        //}

        //void AddOneLong(Dictionary<string, (Type type, BindingSource bs)> dictionary)
        //{
        //    dictionary.Add("A_long", (typeof(long), _bindingSource));
        //}

        //void AddTwoDistinctParameters(Dictionary<string, (Type type, BindingSource bs)> dictionary)
        //{
        //    dictionary.Add("A_string", (typeof(String), _bindingSource));
        //    dictionary.Add("An_int", (typeof(int), _bindingSource));
        //}

        //void AddThreeParameters(Dictionary<string, (Type type, BindingSource bs)> dictionary)
        //{
        //    dictionary.Add("A_string", (typeof(String), _bindingSource));
        //    dictionary.Add("An_int", (typeof(int), _bindingSource));
        //    dictionary.Add("A_second_string", (typeof(String), _bindingSource));

        //}
    }
}
