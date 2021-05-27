INSERT INTO METRIC_CONVERSIONS (
    FromMetricId,
    ToMetricId,
    Multiplier
) VALUES (
    (SELECT Id FROM METRIC WHERE lower(Name) = 'gram'),
    (SELECT Id FROM METRIC WHERE lower(Name) = 'kilogram'),
    1000
);

INSERT INTO METRIC_CONVERSIONS (
    FromMetricId,
    ToMetricId,
    Multiplier
) VALUES (
    (SELECT Id FROM METRIC WHERE lower(Name) = 'kilogram'),
    (SELECT Id FROM METRIC WHERE lower(Name) = 'gram'),
    0.001
);

INSERT INTO METRIC_CONVERSIONS (
    FromMetricId,
    ToMetricId,
    Multiplier
) VALUES (
    (SELECT Id FROM METRIC WHERE lower(Name) = 'millilitre'),
    (SELECT Id FROM METRIC WHERE lower(Name) = 'litre'),
    1000
);

INSERT INTO METRIC_CONVERSIONS (
    FromMetricId,
    ToMetricId,
    Multiplier
) VALUES (
    (SELECT Id FROM METRIC WHERE lower(Name) = 'litre'),
    (SELECT Id FROM METRIC WHERE lower(Name) = 'millilitre'),
    0.001
);