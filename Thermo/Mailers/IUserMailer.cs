using Mvc.Mailer;

namespace Thermo.Mailers
{ 
    public interface IUserMailer
    {
        MvcMailMessage HightAlarme(float val, int equipementid);
			MvcMailMessage Contact();
            MvcMailMessage LowLevel(float val, int equipementid);
	}
}