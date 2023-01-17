PRAGMA foreign_keys = 0;

CREATE TABLE sqlitestudio_temp_table AS SELECT *
                                          FROM usuarios;

DROP TABLE usuarios;

CREATE TABLE usuarios (
    id        INTEGER PRIMARY KEY AUTOINCREMENT
                      UNIQUE,
    nome      TEXT    CONSTRAINT "" NOT NULL,
    sobrenome TEXT    CONSTRAINT "" NOT NULL,
    idade     INTEGER CONSTRAINT [0] NOT NULL
);

INSERT INTO usuarios (
                         id,
                         nome,
                         sobrenome
                     )
                     SELECT id,
                            nome,
                            sobrenome
                       FROM sqlitestudio_temp_table;

DROP TABLE sqlitestudio_temp_table;

PRAGMA foreign_keys = 1;