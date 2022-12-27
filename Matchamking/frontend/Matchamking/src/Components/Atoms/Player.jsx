import React from 'react'
import styled from 'styled-components'
import StyledBox from './BoxStyle'
import Draggable from 'react-draggable'

const PlayerBox = styled(StyledBox)`
    display: flex;
    cursor: pointer;
    height: 50px;
    font-size: 16px;
    padding-top: 0.5rem;
    padding-bottom: 0.5rem;
    width: 100%;
`

const Winrate = styled.div`
   text-align: left;
    width: 25%;
    margin-left: 1rem;
`

const PlayerName = styled.div`
    text-align: left;
    width: 50%;
`

const Add = styled.div`
   text-align: right;
    width: 25%;
    margin-right: 1rem;
`

const Player = (
    {winrate, playername, setPlayerClicked}
    ) => {

    return (
        <PlayerBox>
            <Winrate>{winrate}</Winrate>
            <PlayerName>{playername}</PlayerName>
            <Add onClick={() => {
                 return setPlayerClicked({
                    playername: playername,
                    winrate: winrate
                })
                }
            }>Añadir</Add>
        </PlayerBox>
  )
}

export default Player