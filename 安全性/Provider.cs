using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Security;



// 用户提供程序，只有登录功能
class SampleMembershipProvider : MembershipProvider
{
	private Dictionary<string, string> users = new Dictionary<string, string>();
	internal static string ManagerUserName = "Manager".ToLowerInvariant();
	internal static string EmployeeUserName = "Emploee".ToLowerInvariant();

	public override void Initialize(string name, NameValueCollection config)
	{
		users.Add(ManagerUserName, "");
		users.Add(EmployeeUserName, "");
		base.Initialize(name, config);
	}

	public override bool ValidateUser(string username, string password)
	{
		if (users.ContainsKey(username.ToLowerInvariant()))
			return password.Equals(users[username.ToLowerInvariant()]);
		return false;
	}

	#region		未实现抽象方法
	//-------------------------------------------
	public override bool EnablePasswordRetrieval => throw new NotImplementedException();

	public override bool EnablePasswordReset => throw new NotImplementedException();

	public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

	public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

	public override int PasswordAttemptWindow => throw new NotImplementedException();

	public override bool RequiresUniqueEmail => throw new NotImplementedException();

	public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

	public override int MinRequiredPasswordLength => throw new NotImplementedException();

	public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

	public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

	public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
	{
		throw new NotImplementedException();
	}

	public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
	{
		throw new NotImplementedException();
	}

	public override string GetPassword(string username, string answer)
	{
		throw new NotImplementedException();
	}

	public override bool ChangePassword(string username, string oldPassword, string newPassword)
	{
		throw new NotImplementedException();
	}

	public override string ResetPassword(string username, string answer)
	{
		throw new NotImplementedException();
	}

	public override void UpdateUser(MembershipUser user)
	{
		throw new NotImplementedException();
	}

	public override bool UnlockUser(string userName)
	{
		throw new NotImplementedException();
	}

	public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
	{
		throw new NotImplementedException();
	}

	public override MembershipUser GetUser(string username, bool userIsOnline)
	{
		throw new NotImplementedException();
	}

	public override string GetUserNameByEmail(string email)
	{
		throw new NotImplementedException();
	}

	public override bool DeleteUser(string username, bool deleteAllRelatedData)
	{
		throw new NotImplementedException();
	}

	public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
	{
		throw new NotImplementedException();
	}

	public override int GetNumberOfUsersOnline()
	{
		throw new NotImplementedException();
	}

	public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
	{
		throw new NotImplementedException();
	}

	public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
	{
		throw new NotImplementedException();
	}
	#endregion
}

// 角色提供程序
class SampleRoleProvider : RoleProvider
{
	internal static string ManagerRoleName = "Manager".ToLowerInvariant();
	internal static string EmployeeRoleName = "Employee".ToLowerInvariant();

	public override string[] GetRolesForUser(string username)
	{
		if (string.Compare(username, SampleMembershipProvider.ManagerUserName, true) == 0)
			return new string[] { ManagerRoleName };
		if (string.Compare(username, SampleMembershipProvider.EmployeeUserName, true) == 0)
			return new string[] { EmployeeRoleName };
		return new string[0];
	}

	public override bool IsUserInRole(string username, string roleName)
	{
		foreach (var role in GetRolesForUser(username))
		{
			if (role.Equals(roleName))
				return true;
		}
		return false;
	}


	#region 未实现抽象方法
	public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public override void AddUsersToRoles(string[] usernames, string[] roleNames)
	{
		throw new NotImplementedException();
	}

	public override void CreateRole(string roleName)
	{
		throw new NotImplementedException();
	}

	public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
	{
		throw new NotImplementedException();
	}

	public override string[] FindUsersInRole(string roleName, string usernameToMatch)
	{
		throw new NotImplementedException();
	}

	public override string[] GetAllRoles()
	{
		throw new NotImplementedException();
	}

	public override string[] GetUsersInRole(string roleName)
	{
		throw new NotImplementedException();
	}

	public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
	{
		throw new NotImplementedException();
	}

	public override bool RoleExists(string roleName)
	{
		throw new NotImplementedException();
	}
	#endregion
}