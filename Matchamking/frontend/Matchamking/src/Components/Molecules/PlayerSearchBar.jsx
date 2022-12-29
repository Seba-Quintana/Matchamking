import React from 'react'
import HeaderText from '../Atoms/HeaderText'
import SearchBox from '../Atoms/SearchBox'
import styled from 'styled-components'

const PlayerSearchBar = ({setSearchValue}) => {
  return (
    <>
        <HeaderText text='¿Quiénes juegan?'></HeaderText>
        <SearchBox setSearchValue={setSearchValue} text='Buscá jugadores...'></SearchBox>
    </>
  )
}

export default PlayerSearchBar