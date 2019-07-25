﻿using MasterMemory.Tests.TestStructures;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System.Text;
using System;

namespace MasterMemory.Tests.Tables
{
   public sealed partial class TestMasterTable : TableBase<TestMaster>
   {
        readonly Func<TestMaster, int> primaryIndexSelector;


        public TestMasterTable(TestMaster[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.TestID;
        }


        public RangeView<TestMaster> FindByTestID(int key)
        {
            return FindManyCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key);
        }

        public RangeView<TestMaster> FindClosestByTestID(int key, bool selectLower = true)
        {
            return FindManyClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<TestMaster> FindRangeByTestID(int min, int max, bool ascendant = true)
        {
            return FindManyRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

    }
}