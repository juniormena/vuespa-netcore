<template>
  <el-select v-model="value"  clearable placeholder="Select">
    <el-option @change="Seleccionar(value)"
      v-for="item in data"
      :key="item.id"
      :label="item.name"
      :value="item.id">
    </el-option>
  </el-select>
</template>

<script>
  export default {
    data() {
      return {
        data:[],
        id:0,
        name:null,
        value:null
    }
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
      seleccionar(v){
        this.$emit("seleccionado",v)
      
  }
  }
  }
</script>


