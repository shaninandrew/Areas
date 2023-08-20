
-- Таблицы
-- Products: id, name, type
-- Category: id, category
-- links: id, id_product, id_category

Select p.name, c.category from Products as p 
INNER JOIN links as l ON l.id_product = p.id
LEFT OUTER JOIN category as c ON c.id = l.id_category
GO

-- с вариантом отбора
Select p.name, c.category from Products as p 
INNER JOIN links as l ON l.id_product = p.id
LEFT OUTER JOIN category as c ON c.id = l.id_category
WHERE p.name LIKE '%товара который ищем%'
GO