using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Telephony.Gsm;
using Android.Util;
using Android.Views;
using Android.Widget;
using Environment = System.Environment;

namespace FriendWrangler.Droid.Classes
{
     


    [BroadcastReceiver(Enabled = true, Label = "SMS Receiver")]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SmsBroadcastReceiver : BroadcastReceiver
    {

        public delegate void MessageReceivedEventHandler(string message, string contactinfo);

        public event MessageReceivedEventHandler Received;

        private const string Tag = "SMSBroadcastReceiver";
        private const string IntentAction = "android.provider.Telephony.SMS_RECEIVED";

        public override void OnReceive(Context context, Intent intent)
        {
            Log.Info(Tag, "Intent received: " + intent.Action);

            if (intent.Action != IntentAction) return;

            var bundle = intent.Extras;

            if (bundle == null) return;

            var pdus = bundle.Get("pdus");
            var castedPdus = JNIEnv.GetArray<Java.Lang.Object>(pdus.Handle);

            var msgs = new SmsMessage[castedPdus.Length];

            var sb = new StringBuilder();

            for (var i = 0; i < msgs.Length; i++)
            {
                var bytes = new byte[JNIEnv.GetArrayLength(castedPdus[i].Handle)];
                JNIEnv.CopyArray(castedPdus[i].Handle, bytes);

                msgs[i] = SmsMessage.CreateFromPdu(bytes);

                sb.Append(string.Format("SMS From: {0}{1}Body: {2}{1}", msgs[i].OriginatingAddress, Environment.NewLine, msgs[i].MessageBody));
                if (Received != null) Received(msgs[i].MessageBody , msgs[i].OriginatingAddress);
            }

            Toast.MakeText(context, sb.ToString(), ToastLength.Long).Show();
        }
    }
}