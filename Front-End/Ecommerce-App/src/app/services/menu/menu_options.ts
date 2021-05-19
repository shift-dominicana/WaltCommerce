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
          key: 'crud-products',
          url: '/mantenimientos/productos',
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
          title: 'Ventas',
          key: 'view-users',
          url: '/consultas/ventas',
        },
        {
          title: 'Ordenes Abiertas',
          key: 'view-users',
          url: '/consultas/ordenes-abiertas',
        }

      ],
    },
  ]
  