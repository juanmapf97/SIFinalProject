using System;
namespace SIFinalProject
{
	public class User
	{
		#region Private Properties

		private string _firstName;
		private string _lastName;
		private string _email;
		private string _city;
		private string _state;
		private string _country;
		private string _cellphone;
		private string _telephone;
		private string _hotel;

		#endregion

		#region Private Properties

		public string FirstName { 
			get { return _firstName; } 
			set { _firstName = value; } 
		}
		public string LastName {
			get { return _lastName; }
			set { _lastName = value; }
		}
		public string Email {
			get { return _email; }
			set { _email = value; }
		}
		public string City {
			get { return _city; }
			set { _city = value; }
		}
		public string State {
			get { return _state; }
			set { _state = value; }
		}
		public string Country {
			get { return _country; }
			set { _country = value; }
		}
		public string Cellphone {
			get { return _cellphone; }
			set { _cellphone = value; }
		}
		public string Telephone {
			get { return _telephone; }
			set { _telephone = value; }
		}
		public string Hotel {
			get { return _hotel; }
			set { _hotel = value; }
		}

		#endregion

		#region Constructors

		public User(string firstName, string lastName, string email, string city, string state, string country, string cell, string hotel, string tel)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			City = city;
			State = state;
			Country = country;
			Cellphone = cell;
			Telephone = tel;
			Hotel = hotel;
		}

		public User()
		{
		}

		#endregion
	}
}
