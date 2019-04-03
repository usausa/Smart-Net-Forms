﻿namespace Smart.Forms.Validation
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Smart.ComponentModel;

    public sealed class ValidationValue<T> : NotificationValue<T>, IValidatable, IValidationResult
    {
        private bool hasError;

        public List<IValidator<T>> Validators { get; } = new List<IValidator<T>>();

        public ObservableCollection<string> Errors { get; } = new ObservableCollection<string>();

        public bool HasError
        {
            get => hasError;
            set
            {
                Errors.Clear();
                SetProperty(ref hasError, value);
            }
        }

        public ValidationValue()
        {
        }

        public ValidationValue(T value)
            : base(value)
        {
        }

        public bool Validate()
        {
            Errors.Clear();

            foreach (var message in Validators.Where(x => !x.Validate(Value)).Select(x => x.ErrorMessage))
            {
                Errors.Add(message);
            }

            HasError = Errors.Count > 0;

            return !HasError;
        }
    }
}
