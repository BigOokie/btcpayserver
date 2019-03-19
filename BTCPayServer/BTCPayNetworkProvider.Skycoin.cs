using NBitcoin;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitSkycoin()
        {
            //not needed: NBitcoin.Altcoins.Skycoin.Instance.EnsureRegistered();
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("SKY");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "Skycoin",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet
                    ? "https://explorer.skycoin.net/app/transaction/{0}"
                    : "https://explorer.skycoin.net/app/transaction/{0}",
                NBitcoinNetwork = nbxplorerNetwork.NBitcoinNetwork,
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "skycoin",
                DefaultRateRules = new[]
                    {
                        "SKY_X = SKY_BTC * BTC_X",
                        "SKY_BTC = binance(SKY_BTC)"
                    },
                CryptoImagePath = "imlegacy/skycoin.png",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                //https://github.com/satoshilabs/slips/blob/master/slip-0044.md
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("5'")
                    : new KeyPath("1'"),
                MinFee = Money.Satoshis(1m)
            });
        }
    }
}
