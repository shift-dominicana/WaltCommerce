export const getMenuData: any[] = [  
    {
      title: 'Parametros',
      key: 'configs',
      icon: 'fe fe-home',
      children: [
        {
          title: 'Generales',
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
  ]
  