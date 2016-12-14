using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NetworkPage : ContentPage
	{
		Network network = new Network();

		public NetworkPage()
		{
			
			InitializeComponent();
			Device.StartTimer(new TimeSpan(0, 0, 2), () =>
			{
				callMethods();
				return false;
			});
		}

		void callMethods()
		{
			isNetworkConnected();
			networkConnectionType();
			extraConnectionInfo();
			connectionState();
			mobileSignal();
		}

		void mobileSignal()
		{
			lblMobileStrenght.Text = network.mobileStrengthInfo();
		}

		void connectionState()
		{
			lblConnState.Text = network.connectionStateInfo();
			lblConnDetailState.Text = network.connectionDetailStateInfo();
		}

		void isNetworkConnected()
		{
			lblStat.Text = network.connected();
		}

		void networkConnectionType()
		{
			lblconnType.Text = network.connectionType();
		}

		void extraConnectionInfo()
		{
			lblextConnInfo.Text = network.connectionExtraInfo();
		}

	}
}
