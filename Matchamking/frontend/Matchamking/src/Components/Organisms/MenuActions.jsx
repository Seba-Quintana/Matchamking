import ClickBox from "../Atoms/ClickBox";
import styled from "styled-components";
import React from 'react'
import {Link} from 'react-router-dom'

const StyledClickBox = styled(ClickBox)`
  margin: 1rem;
`

const StyledClickBoxes = styled.div`
    display: flex;
    flex-direction: column;
    height: 70%;
    width: 90%;
    align-items: center;
    text-align: center;
`

const MenuActions = () => {
  return (
    <StyledClickBoxes>
            <ClickBox text="Agregar nuevo jugador" redirection='/addplayer'></ClickBox>
            <ClickBox text="Nuevo matchmaking" redirection='/matchmaking'></ClickBox>
            <ClickBox text="Historial de partidos" redirection='/history'></ClickBox>
            <ClickBox text="Tabla de clasificación" redirection='/leaderboard'></ClickBox>
            <ClickBox text="Administración" redirection='/admin'></ClickBox>
    </StyledClickBoxes>
  )
}

export default MenuActions