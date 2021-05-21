export const getMenuData: any[] = [  
    {
      title: 'Configuración',
      key: 'configs',
      icon: 'fe fe-home',
      children: [
        {
          title: 'Config. General',
          key: 'Generales',
          url: '/parametros/generales',
        },
      ],
    },
    
    {
      title: 'Mantenimientos',
      key: 'cruds',
      icon: 'fe fe-database',
      children: [
        {
          title: 'Productos',
          key: 'crud-product',
          url: '/mantenimientos/productos',
        },
        {
          title: 'Categorias de productos',
          key: 'crud-category',
          url: '/mantenimientos/prod-categorias',
        },
      ],
    },
    {
      title: 'Consultas',
      key: 'views',
      icon: 'fe fe-database',
      children: [
        {
          title: 'Usuarios',
          key: 'view-users',
          url: '/consultas/usuarios',
        },
        {
          title: 'Ordenes',
          key: 'view-orders',
          url: '/consultas/ordenes',
        }

      ],
    },
  ]
  