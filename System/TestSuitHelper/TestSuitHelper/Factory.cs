#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="Factory.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright

using System;
using System.Diagnostics;
using System.Reflection;

namespace Siemens.BASys.Internal.TestSuitHelper
{
	/// <summary>
	/// A Factory for TestSuitHelper library.
	/// </summary>
	public static class Factory
	{
		private static readonly Lazy<ITestsRetriever> LazyTestSuitGenerator = new Lazy<ITestsRetriever>(() =>
		{
			var stackTrace = new StackTrace();

			var declaringType = stackTrace.GetFrame(5).GetMethod().DeclaringType;

			if (declaringType != null)
				return new TestsRetriever(declaringType.Assembly);

			throw new InvalidOperationException("Calling Assembly not found!");
		});

		/// <summary>
		/// Gets the test retriever.
		/// </summary>
		/// <value>
		/// The test retriever.
		/// </value>
		public static ITestsRetriever TestsRetriever
		{
			get { return LazyTestSuitGenerator.Value; }
		}

		/// <summary>
		/// Gets a new instance <see cref="ITestsRetriever"/>.
		/// </summary>
		/// <param name="testAssembly">The assembly to look test classes into.</param>
		/// <returns></returns>
		public static ITestsRetriever GetTestRetriever(Assembly testAssembly)
		{
			return new TestsRetriever(testAssembly);
		}
	}
}

#region Copyright

//-----------------------------------------------------------------------
// <Copyright file="Factory.cs" company="Siemens Switzerland Ltd.">
//    Copyright (C) Siemens Switzerland Ltd 2015. All Rights Reserved. Confidential
// </Copyright>
// <Summary>Tests.</Summary>
// <Author>Shrikant Mali - shrikant.mali@siemens.com</Author>
//-----------------------------------------------------------------------

#endregion Copyright