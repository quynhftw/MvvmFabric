﻿using System;
using System.Windows.Input;
using BrentEdwards.MVVM.Messaging;
using BrentEdwards.MVVM.Movies.Core.Messaging;
using BrentEdwards.MVVM.Movies.Core.Models;

namespace BrentEdwards.MVVM.Movies.Core.ViewModels
{
	public sealed class AdvancedSearchViewModel : CoreViewModelBase
	{
		public AdvancedSearchViewModel()
			: base()
		{
			SearchCommand = new ActionCommand(Search);
		}

		public ICommand SearchCommand { get; private set; }

		public IMessageBus MessageBus { get; set; }

		private String _Keywords;
		public String Keywords
		{
			get { return _Keywords; }
			set
			{
				_Keywords = value;
				NotifyPropertyChanged("Keywords");
			}
		}

		public Array Genres
		{
			get
			{
				return Enum.GetValues(typeof(Genres));
			}
		}

		private Genres? _SelectedGenre;
		public Genres? SelectedGenre
		{
			get { return _SelectedGenre; }
			set
			{
				_SelectedGenre = value;
				NotifyPropertyChanged("SelectedGenre");
			}
		}

		public Array Ratings
		{
			get
			{
				return Enum.GetValues(typeof(Ratings));
			}
		}

		private Ratings? _SelectedRating;
		public Ratings? SelectedRating
		{
			get { return _SelectedRating; }
			set
			{
				_SelectedRating = value;
				NotifyPropertyChanged("SelectedRating");
			}
		}

		public void Search()
		{
			var message = new SearchMessage(Keywords, SelectedGenre, SelectedRating);

			MessageBus.Publish<SearchMessage>(message);
		}
	}
}
