﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using rbn.Models;

namespace rbn.Filters
{
	[AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true )]
	public sealed class InitializeMembershipAttribute : ActionFilterAttribute
	{
		private static MembershipInitializer initializer;
		private static object initializerLock = new object();
		private static bool isInitialized;

		public override void OnActionExecuting( ActionExecutingContext filterContext )
		{
			// Ensure ASP.NET Simple Membership is initialized only once per app start
			LazyInitializer.EnsureInitialized( ref initializer, ref isInitialized, ref initializerLock );
		}

		private class MembershipInitializer
		{
			public MembershipInitializer()
			{
				Database.SetInitializer<UsersContext>( null );

				//try
				//{
				//	using (var context = new UsersContext())
				//	{
				//		if (!context.Database.Exists())
				//		{
				//			// database must exist for users to register
				//		}
				//	}

				//	WebSecurity.InitializeDatabaseConnection( "DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: false );
				//}
				//catch (Exception ex)
				//{
				//	throw new InvalidOperationException( "The ASP.NET Membership database could not be initialized.", ex );
				//}
			}
		}
	}
}
