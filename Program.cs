using NBitcoin;

public class Program
{

	public static int _walletamount = 1000000;

	public static void Main()
	{

		HashSet<Key> hashSet = new HashSet<Key>();
		for (int i = 0; i < _walletamount; i++)
		{
			Key item = new Key();
			hashSet.Add(item);
		}
		if (!Directory.Exists("INFO"))
		{
			Directory.CreateDirectory("INFO");
		}
		if (File.Exists("INFO\\address.txt"))
		{
			File.Delete("INFO\\address.txt");
		}
		if (File.Exists("INFO\\secretkey.txt"))
		{
			File.Delete("INFO\\secrekey.txt");
		}
		using (StreamWriter streamWriter = File.CreateText("INFO\\address.txt"))
		{
			using (StreamWriter streamWriter2 = File.CreateText("INFO\\secretkey.txt"))
			{
				foreach (Key key in hashSet)
				{
					string text = key.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main).ToString();
					streamWriter.WriteLine(text);
					Console.WriteLine(text + ":" + key.GetBitcoinSecret(Network.Main) + "  " + System.DateTimeOffset.Now.ToString("hh:mm:ss.fff"));
				}
				streamWriter.Flush();
				streamWriter2.Flush();
			}
		}
	}
}
