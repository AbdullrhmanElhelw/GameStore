﻿using GameStore.Domain.Utilities;

namespace GameStore.Domain.Shared;

public record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        Check.NotEmpty(value, nameof(value));
        Value = value;
    }

    public static implicit operator string(Name name)
    {
        return name.Value;
    }

    public static implicit operator Name(string value)
    {
        return new Name(value);
    }
}