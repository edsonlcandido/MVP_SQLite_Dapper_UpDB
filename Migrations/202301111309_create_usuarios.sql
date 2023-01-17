CREATE TABLE usuarios (
    id        INTEGER PRIMARY KEY AUTOINCREMENT
                      UNIQUE,
    nome      TEXT    CONSTRAINT "" NOT NULL,
    sobrenome TEXT    CONSTRAINT "" NOT NULL
);
