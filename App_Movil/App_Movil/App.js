import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View,SafeAreaView, FlatList,Button,Image } from 'react-native';
import  React,{ useEffect,useState }  from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

function HomeScreen({ navigation }) {
  const [data, setData] = useState([]);
  const [filteredData, setFilteredData] = useState([]);
  const getProductos=()=>{
    fetch('https://apiclinica.azurewebsites.net/api/Productos')
    .then(res=>res.json())
    .then(data=>{
      setData(data);
      setFilteredData(data);
    })
    .catch(err=>console.log(err.message))
  }

  useEffect(()=>{
    getProductos()
  },[])
  useEffect(()=>{
    navigation.setOptions({
      headerLargeTitle:true,
      headerTitle:"Listado de Productos",
      headerSearchBarOptions:{
        placeholder:"Product",
        onChangeText:(event)=>{
          searchFilterFunction(event.nativeEvent.text);
        },
      },
    });
  },[navigation]);

const searchFilterFunction = (text)=>{
  if(text){
    const newData=data.filter(item=>{
      const itemData=item.nombre ? item.nombre.toUpperCase() : ''.toUpperCase();
      const textData=text.toUpperCase();
      return itemData.indexOf(textData)>-1;
    })
    setFilteredData(newData);
  }else{
    setFilteredData(data);
  }
}

  return (
    <SafeAreaView >
  
   
      <FlatList
        data={filteredData}
        keyExtractor={(item,index)=>index.toString()}
        renderItem={({item})=>{
          return(
            <View style={{padding:16,margin:16,alignItems:'center'}}>
              <Image source={{uri:item.imagen}} style={{width:200,height:200}}/>
              <Text>{item.nombre}</Text>
              <Text>{item.marca}</Text>
              <Text>Q.{item.precio}</Text>
              <Button title="Ver Detalle" 
              onPress={()=>{
                navigation.navigate('Detalles de Producto', {
                  item: item
                });
              }}/>
            </View>
          )
        }}
      />
     
    </SafeAreaView>
  );
}

function DetailsScreen({ route, navigation }) {
  const {item} = route.params;
  return (
    <SafeAreaView >
      <View style={{padding:16,margin:16,alignItems:'center'}}>
      <Text>Detalles de Producto</Text>
      <Image source={{uri:item.imagen}} style={{width:200,height:200}}/>
      <Text>Nombre:{item.nombre}</Text>
      <Text>Marca:{item.marca}</Text>
      <Text>Descripcion:{item.descripcion}</Text>
      <Text>Q.{item.precio}</Text>
      <Text>Existencias:{item.existencia} en Clinica:{item.clinica}</Text>
      </View>
    </SafeAreaView>
  );
}


const Stack = createNativeStackNavigator();
function MyStack() {
  return (
    <Stack.Navigator>
      <Stack.Screen name="Listado Productos" component={HomeScreen} />
      <Stack.Screen name="Detalles de Producto" component={DetailsScreen} />
    </Stack.Navigator>
  );
}
export default function App() {
  return (
    <NavigationContainer>
      <MyStack />
    </NavigationContainer>
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
