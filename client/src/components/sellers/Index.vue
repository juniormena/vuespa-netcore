<template>
<div>
<center>
<h2>Clientes</h2>
</center>
 <el-table v-loading="loading" :data="data" style="width: 100%">

 <el-table-column prop="name" label="Nombre" sortable>
 <template slot-scope="scope">
 {{scope.row.lastName}}, {{scope.row.name}}
 </template>
 </el-table-column>
 <el-table-column prop="idNumber" label="Cedula" width="200"sortable></el-table-column>
 <el-table-column prop="email" label="Correo electronico" width="400" sortable></el-table-column>

<el-table-column align="right">
 <template slot-scope="scope">
 <el-button type="danger" class=" fa fa-trash" @click=remove(scope.row.sellerId)> Borrar</el-button>
<el-button class=" fa fa-edit" @click="$router.push(`/sellers/${scope.row.sellerId}/edit`)"> Modificar</el-button>
 </template>
 </el-table-column>
 </el-table>
</div>
</template>

<script>
export default {
  name: "SellerIndex",
  data() {
    return {
      data:[],
      loading:false
    };
  },
  created() {
    let self = this;
    self.getAll();
  },
  methods: {
    getAll(){
      let self=this;
      self.loading=true;

      self.$store.state.services.sellerService
      .getAll()
      .then(r =>{
        self.loading=false;
        self.data=r.data;
      })
      .catch(r =>{
        self.$message({
          message:"Ocurrio un problema",
          type:"error"
        });
      });

      },

      remove(id){
      let self =this;
      self.$confirm('Estas seguro que quieres eliminar','Confirmacion',{
        CancelButtonText:'Cancelar',
        confirmButtonText:'Si',
        type:'warning'
      }).then(()=>{
        _remove();
      }).catch(()=>{
        
      });

      function _remove(){
      self.$store.state.services.sellerService
      .remove(id)
      .then(r =>{
        self.loading=false;
        self.getAll();
      })
      .catch(r =>{
        self.$message({
          message:"Ocurrio un problema",
          type:"error"
        });
      });
      }
      }
    }
};
</script>