import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View,SafeAreaView, FlatList,Button,Image } from 'react-native';
import { useEffect,useState } from 'react';
export default function App() {
  const [data, setData] = useState([]);
  const getEmpleados=()=>{
    fetch('https://apiclinica.azurewebsites.net/api/Productos')
    .then(res=>res.json())
    .then(data=>{
      console.log("data",data)
      setData(data);
    })
    .catch(err=>console.log(err.message))
  }

  useEffect(()=>{
    getEmpleados()
  },[])

  return (
    <SafeAreaView >
      <View>
        <Text style={styles.textHeader}>Listado de Productos</Text>
      </View>
     
        <FlatList
          data={data}
          keyExtractor={(item,index)=>index.toString()}
          renderItem={({item})=>{
            return(
              <View style={{padding:16,margin:16,alignItems:'center'}}>
                <Image source={{uri:item.imagen}} style={{width:200,height:200}}/>
                <Text>{item.nombre}</Text>
                <Text>{item.marca}</Text>
                <Text>Q.{item.precio}</Text>
                <Button title="Ver Detalle" onPress={()=>{console.log(item.idProducto)}}/>
              </View>
            )
          }}
        />
       
      </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  textHeader:{
    fontSize:20,
    fontWeight:'bold'
  }
});
