import { StatusBar } from "expo-status-bar";
import { SafeAreaView, FlatList, Text, View, ScrollView, Image, TouchableOpacity } from "react-native";
import React,{useState,useEffect} from "react";
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

  
return(
  <SafeAreaView className="flex-1 items-center justify-center bg-gray-200 dark:bg-black">
  <FlatList
data={filteredData}
keyExtractor={(item,index) => index.toString()}
renderItem={({ item }) => {
  return(
    <View className={"w-full bg-white dark:bg-gray-50/10 rounded-3xl p-5 my-5"}>
    <View className="bg-white rounded-xl ">
      <Image
        source={{ uri: item.imagen }}
        className={"w-full h-72"}
        style={{ resizeMode: "contain" }}
      />
    </View>
    <View className="mt-5 " >
      <Text className={"text-2xl font-semibold dark:text-white "}>{item.nombre}                                                </Text>
      <Text
        numberOfLines={2}
        className={"text-xl text-black/60 dark:text-white/70"}
      >
        {item.marca}
      </Text>
      <View className={"flex-row justify-between items-center my-3"}>
        <Text className={"text-2xl font-extrabold dark:text-white"}>
          Q.{item.precio}
        </Text>
      </View>

      <TouchableOpacity className="flex-row justify-center rounded-full bg-black/90 dark:bg-white/90 p-3 w-10/12 self-center mt-5"
      onPress={()=>{
        navigation.navigate('Detalles de Producto', {
          item: item
        });
      }}>
        <Text className="text-white dark:text-black font-bold">
          Ver Detalles
        </Text>
      </TouchableOpacity>
    </View>
  </View>
  )
}}
contentContainerStyle={{
  paddingHorizontal: 15,
}}
/>
<StatusBar style={"dark"} />
</SafeAreaView>
);

}




function DetailsScreen({ route, navigation }) {
  const {item} = route.params;
  return (
    <SafeAreaView className="flex-1 items-center justify-center bg-gray-200 dark:bg-black pb-5">
    
      <ScrollView className={"w-full h-full bg-white dark:bg-gray-50/10  p-5 my-5"}>
      <View className="bg-white rounded-xl ">
        <Image
          source={{ uri: item.imagen }}
          className={"w-full h-72"}
          style={{ resizeMode: "contain" }}
        />
      </View>
      <View className="mt-5" >
        <Text className={"text-2xl font-semibold dark:text-white "}>{item.nombre}                                                </Text>
        <Text className={"text-xl font-semibold dark:text-white "}>{item.marca}                                                </Text>
        <Text
          className={"text-xl text-black/60 dark:text-white/70"}
        >
          {item.descripcion}
        </Text>
        <View className={"flex-row justify-between items-center my-3"}>
        <View className={"flex-row items-center gap-3"}>
        {item.existencia > 0? (<Text className={"text-2xl font-extrabold dark:text-white"}>Stock:{item.existencia}{"\n"}</Text>) : (<Text className={"text-2xl font-extrabold dark:text-red-600"}>Agotado!{"\n"}</Text>)}
          </View>
          <Text className={"text-2xl font-extrabold dark:text-white"}>
            Q.{item.precio}
            {"\n"}
          </Text>
        </View>
      </View>
    </ScrollView>
   

  
  <StatusBar style={"dark"} />
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