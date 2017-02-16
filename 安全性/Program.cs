using System;
using System.Text;
using System.Security.Claims;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Cryptography;

class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
		var principal = ClaimsPrincipal.Current as WindowsPrincipal;

		ShowUserInfo(principal);

		Console.WriteLine();
		ShowMessage();

		Console.WriteLine();
		Signature();
	}

	private static void ShowUserInfo(WindowsPrincipal principal)
	{
		var identity = principal.Identity as WindowsIdentity;
		Console.WriteLine("IdentityType: {0}", identity);
		Console.WriteLine("Name: {0}", identity.Name);
		Console.WriteLine("'Users'? {0}", principal.IsInRole(WindowsBuiltInRole.User));
		Console.WriteLine("'Administrators'? {0}", principal.IsInRole(WindowsBuiltInRole.Administrator));
		Console.WriteLine("Authenticated: {0}", identity.IsAuthenticated);
		Console.WriteLine("AuthType: {0}", identity.AuthenticationType);
		Console.WriteLine("Anonymous? {0}", identity.IsAnonymous);
		Console.WriteLine("Token: {0}", identity.Token);

		Console.WriteLine();
		Console.WriteLine("Claims");
		foreach (var claim in principal.Claims)
		{
			Console.WriteLine("Subject: {0}", claim.Subject);
			Console.WriteLine("Issuer: {0}", claim.Issuer);
			Console.WriteLine("Type: ", claim.Type);
			Console.WriteLine("Value type: {0}", claim.ValueType);
			Console.WriteLine("Value: {0}", claim.Value);
			foreach (var prop in claim.Properties)
			{
				Console.WriteLine("\tProperty: {0} {1}", prop.Key, prop.Value);
			}
			Console.WriteLine();
		}
	}

	// 指定角色才能执行
	[PrincipalPermission(SecurityAction.Demand, Role = @"KERNEL\Admin")]
	static void ShowMessage()
	{
		Console.WriteLine("The current principal is logged in locally");
	}

	// 签名算法
	static void Signature()
	{
		CngKey aliceKey = CngKey.Create(CngAlgorithm.ECDsaP256);
		byte[] alicePubKey = aliceKey.Export(CngKeyBlobFormat.GenericPublicBlob);

		byte[] data = Encoding.UTF8.GetBytes("Alice");

		// 签名
		byte[] signature;
		using (var signingAlg = new ECDsaCng(aliceKey))
		{
			signature = signingAlg.SignData(data);
			signingAlg.Clear();
		}
		Console.WriteLine("Alice created signature: {0}",
			Convert.ToBase64String(signature));

		// 验证签名
		bool verify;
		using (var key = CngKey.Import(alicePubKey, CngKeyBlobFormat.GenericPublicBlob))
		using (var signingAlg = new ECDsaCng(key))
		{
			verify = signingAlg.VerifyData(data, signature);
			signingAlg.Clear();
		}
		if (verify)
			Console.WriteLine("Alice signature verified successfully");
	}
}