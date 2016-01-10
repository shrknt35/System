#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="ITestRetriever.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright

using System;
using System.Collections.Generic;

namespace Siemens.BASys.Internal.TestSuitHelper
{
	/// <summary>
	/// Retrievers the different test cases depending on their attributes.
	/// </summary>
	public interface ITestRetriever
	{
		/// <summary>
		/// Gets all tests who have <see cref="NUnit.Framework.TestFixtureAttribute"/>.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="NUnit.Framework.TestFixtureAttribute"/> attribute from the calling assembly.
		/// </returns>
		/// <remarks>
		/// This method is different from <see cref="GetUnitTests"/> as this method will return all Unit tests
		/// event if they have <see cref="PerformanceTestAttribute"/>,
		/// <see cref="StressTestAttribute"/> OR <see cref="IntegrationTestAttribute"/> associated with it.
		/// </remarks>
		IEnumerable<Type> GetAllTests();

		/// <summary>
		/// Gets all the unit tests class types from the calling assembly who has
		/// <see cref="NUnit.Framework.TestFixtureAttribute"/> Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="NUnit.Framework.TestFixtureAttribute"/> attribute from the calling assembly.
		/// </returns>
		/// <remarks>This method will ignore tests who have <see cref="PerformanceTestAttribute"/>,
		/// <see cref="StressTestAttribute"/> OR <see cref="IntegrationTestAttribute"/>.
		/// To Get all the tests regardless of this fact, call <see cref="GetAllTests"/> Method.</remarks>
		IEnumerable<Type> GetUnitTests();

		/// <summary>
		/// Gets all the Performance Tests types from the calling assembly who has
		/// <see cref="PerformanceTestAttribute"/> and <see cref="NUnit.Framework.TestFixtureAttribute"/>
		/// Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="PerformanceTestAttribute"/> and
		/// <see cref="NUnit.Framework.TestFixtureAttribute"/> attributes from the calling assembly.
		/// </returns>
		IEnumerable<Type> GetPerformanceTests();

		/// <summary>
		/// Gets all the Stress Tests types from the calling assembly who has
		/// <see cref="StressTestAttribute"/> and <see cref="NUnit.Framework.TestFixtureAttribute"/>
		/// Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="StressTestAttribute"/> and
		/// <see cref="NUnit.Framework.TestFixtureAttribute"/> attributes from the calling assembly.
		/// </returns>
		IEnumerable<Type> GetStressTests();

		/// <summary>
		/// Gets all the Integration Tests types from the calling assembly who has
		/// <see cref="IntegrationTestAttribute"/> and <see cref="NUnit.Framework.TestFixtureAttribute"/>
		/// Attribute.
		/// </summary>
		/// <returns>
		/// All type who have <see cref="IntegrationTestAttribute"/> and
		/// <see cref="NUnit.Framework.TestFixtureAttribute"/> attributes from the calling assembly.
		/// </returns>
		IEnumerable<Type> GetIntegrationTests();
	}
}

#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="ITestRetriever.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright