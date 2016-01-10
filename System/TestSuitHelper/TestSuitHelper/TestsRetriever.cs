#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="TestsRetriever.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Siemens.BASys.Internal.TestSuitHelper
{
	/// <summary>
	/// Generates the
	/// </summary>
	internal class TestsRetriever : ITestsRetriever
	{
		private readonly Assembly assembly;

		public TestsRetriever(Assembly assemblyPath)
		{
			this.assembly = assemblyPath;
		}

		/// <summary>
		/// Gets all tests who have <see cref="NUnit.Framework.TestFixtureAttribute" />.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="NUnit.Framework.TestFixtureAttribute" /> attribute from the calling assembly.
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		/// <remarks>
		/// This method is different from <see cref="GetUnitTests" /> as this method will return all Unit tests
		/// event if they have <see cref="PerformanceTestAttribute" />,
		/// <see cref="StressTestAttribute" /> OR <see cref="IntegrationTestAttribute" /> associated with it.
		/// </remarks>
		public IEnumerable<Type> GetAllTests()
		{
			return GetAllTypes<TestFixtureAttribute>().ToList();
		}

		/// <summary>
		/// Gets all the unit tests class types from the calling assembly who has
		/// <see cref="NUnit.Framework.TestFixtureAttribute" /> Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="NUnit.Framework.TestFixtureAttribute" /> attribute from the calling assembly.
		/// </returns>
		/// <remarks>
		/// This method will ignore tests who have <see cref="PerformanceTestAttribute" />,
		/// <see cref="StressTestAttribute" /> OR <see cref="IntegrationTestAttribute" />.
		/// To Get all the tests regardless of this fact, call <see cref="GetAllTests" /> Method.
		/// </remarks>
		public IEnumerable<Type> GetUnitTests()
		{
			return
				this.GetAllTests()
					.Except(this._GetPerformanceTests())
					.Except(this._GetStressTests())
					.Except(this._GetIntegrationTests())
					.ToList();
		}

		/// <summary>
		/// Gets all the Performance Tests types from the calling assembly who has
		/// <see cref="PerformanceTestAttribute" /> and <see cref="NUnit.Framework.TestFixtureAttribute" />
		/// Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="PerformanceTestAttribute" /> and
		/// <see cref="NUnit.Framework.TestFixtureAttribute" /> attributes from the calling assembly.
		/// </returns>
		public IEnumerable<Type> GetPerformanceTests()
		{
			return this._GetPerformanceTests().ToList();
		}

		/// <summary>
		/// Gets all the Stress Tests types from the calling assembly who has
		/// <see cref="StressTestAttribute" /> and <see cref="NUnit.Framework.TestFixtureAttribute" />
		/// Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="StressTestAttribute" /> and
		/// <see cref="NUnit.Framework.TestFixtureAttribute" /> attributes from the calling assembly.
		/// </returns>
		public IEnumerable<Type> GetStressTests()
		{
			return this._GetStressTests().ToList();
		}

		/// <summary>
		/// Gets all the Integration Tests types from the calling assembly who has
		/// <see cref="IntegrationTestAttribute" /> and <see cref="NUnit.Framework.TestFixtureAttribute" />
		/// Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="IntegrationTestAttribute" /> and
		/// <see cref="NUnit.Framework.TestFixtureAttribute" /> attributes from the calling assembly.
		/// </returns>
		public IEnumerable<Type> GetIntegrationTests()
		{
			return this._GetIntegrationTests().ToList();
		}
		
		private IEnumerable<Type> _GetIntegrationTests()
		{
			return this.GetAllTests().Intersect(this.GetAllTypes<IntegrationTestAttribute>());
		}

		private IEnumerable<Type> _GetPerformanceTests()
		{
			return this.GetAllTests().Intersect(this.GetAllTypes<PerformanceTestAttribute>());
		}

		private IEnumerable<Type> _GetStressTests()
		{
			return this.GetAllTests().Intersect(this.GetAllTypes<StressTestAttribute>());
		}

		private IEnumerable<Type> GetAllTypes<TType>()
		{
			var types = this.assembly.GetTypes();

			var attributeType = typeof(TType);

			return types.Where(type => HasAttribute(type, attributeType));
		}

		private static bool HasAttribute(MemberInfo type, Type attributeType)
		{
			var customAttributes = Attribute.GetCustomAttributes(type);
			return customAttributes.Any(customAttribute => customAttribute.GetType() == attributeType);
		}
	}
}

#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="TestsRetriever.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright