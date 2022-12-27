import React from 'react'
import SearchBox from '../Atoms/SearchBox'
import HeaderText from '../Atoms/HeaderText'


const NewPlayerBar = () => {
  return (
    <>
        <HeaderText text='Crear un nuevo jugador'></HeaderText>
        <SearchBox text='Insertar un nickname'></SearchBox>
    </>
  )
}

export default NewPlayerBar