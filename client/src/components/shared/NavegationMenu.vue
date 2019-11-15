<template>
<el-menu default-active="0">
    <template v-for="item, i in items">
        <el-submenu :index="i.toString()" v-if="item.children !== undefined">
            <template slot="title">
                <i :class="'fa fa-' + item.icon"></i>
                <span>{{ item.text }}</span>
            </template>
            <el-menu-item-group title="Opciones">
                <el-menu-item v-for="child, c in item.children" :index="(i.toString() + c)" @click="redirect(child.path)">
                    <i :class="'fa fa-' + child.icon"></i> <span>{{ child.text }}</span>
                </el-menu-item>
            </el-menu-item-group>    
        </el-submenu>
        <el-menu-item index="2" v-if="item.children === undefined" @click="redirect(item.path)">
            <i :class="'fa fa-' + item.icon"></i>
            <span>{{ item.text }}</span>
        </el-menu-item>
    </template>
</el-menu>
</template>

<script>
export default {
  name: "NavegationMenu",
  data: () => ({
    items: [
      {
        icon: "male",
        text: "Vendedores",
        children: [
          { icon: "plus", text: "Agregar vendedor", path: "/clients/add" },
          { icon: "list", text: "Listado de vendedores", path: "/clients" },
          ]
      },
      {
        icon: "user",
        text: "Clientes",
        children: [
          { icon: "plus", text: "Agregar cliente", path: "/sellers/add" },
          { icon: "list", text: "Listado de clientes", path: "/sellers" },
          ]
      },
       {
        icon: "gift",
        text: "Productos",
        children: [
          { icon: "plus", text: "Agregar producto", path: "/products/add" },
          { icon: "list", text: "Listado de productos", path: "/products" },
          ]
      },
      {
        icon: "credit-card",
        text:"Facturación",
        children: [
          { icon: "plus", text: "Calcular", path: "/solds/add" },
          { icon: "list", text: "Listar", path: "/solds" },
          ]
      },
    ]
  }),
  methods: {
    redirect(path) {
      if(path === undefined) return;
      this.$router.push(path);
    }
  }
};
</script>