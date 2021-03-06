CREATE TABLE METRIC_CONVERSIONS (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    FromMetricId INTEGER NOT NULL,
    ToMetricId INTEGER NOT NULL,
    Multiplier DECIMAL(10,5) NOT NULL
);

ALTER TABLE METRIC_CONVERSIONS
ADD CONSTRAINT metric_conversions_fk_FromMetricId
FOREIGN KEY (FromMetricId)
REFERENCES METRIC(Id);

ALTER TABLE METRIC_CONVERSIONS
ADD CONSTRAINT metric_conversions_fk_ToMetricId
FOREIGN KEY (ToMetricId)
REFERENCES METRIC(Id);

ALTER TABLE METRIC_CONVERSIONS
ADD CONSTRAINT metric_conversions_uq_FromToMetricId
UNIQUE (FromMetricId, ToMetricId);