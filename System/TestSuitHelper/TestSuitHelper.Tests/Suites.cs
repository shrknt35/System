#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="IntegrationTestAttribute.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright

using NUnit.Framework;
using Siemens.BASys.Internal.TestSuitHelper.Tests;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Suites
{
	internal class AllTests
	{
		[Suite]
		public static IEnumerable Suite
		{
			get
			{
				List<Type> suite = new List<Type>();
				IEnumerable[] suites = new IEnumerable[]
                    {Suites.UnitTests.Suite,
                    Suites.PerformanceTests.Suite,
                    Suites.StressTests.Suite,
                    Suites.IntegrationTests.Suite};
				foreach (List<Type> tempSuite in suites)
				{
					foreach (Type testCase in tempSuite)
					{
						suite.Add(testCase);
					}
				}
				return suite;
			}
		}
	}

	internal class UnitTests
	{
		[Suite]
		public static IEnumerable Suite
		{
			get
			{
				List<Type> suite = new List<Type>();
				suite.Add(typeof(Factory_On_TestRetriver_Instantiation));
				return suite;
			}
		}
	}

	internal class PerformanceTests
	{
		[Suite]
		public static IEnumerable Suite
		{
			get
			{
				List<Type> suite = new List<Type>();
				//suite.Add(typeof(/*your test*/));
				return suite;
			}
		}
	}

	internal class StressTests
	{
		[Suite]
		public static IEnumerable Suite
		{
			get
			{
				List<Type> suite = new List<Type>();
				//suite.Add(typeof(/*your test*/));
				return suite;
			}
		}
	}

	internal class IntegrationTests
	{
		[Suite]
		public static IEnumerable Suite
		{
			get
			{
				List<Type> suite = new List<Type>();
				//suite.Add(typeof(/*your test*/));
				return suite;
			}
		}
	}
}

#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="IntegrationTestAttribute.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright