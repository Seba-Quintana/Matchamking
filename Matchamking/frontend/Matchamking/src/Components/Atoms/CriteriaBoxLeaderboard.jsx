import React from 'react'
import styled from 'styled-components'
import CriteriaBox from './CriteriaBox'
import StyledBox from './BoxStyle'

const Box = styled(StyledBox)`
    display: flex;
    height: 18px;
    color: gray;
    font-size: 14px;
    padding-top: 0.5rem;
    padding-bottom: 0.5rem;
    width: 100%;
`

const Position = styled.div`
    text-align: right;
    width: 10%;
`
const PlayerName = styled.div`
    text-align: left;
    width: 30%;
`
const Winrate = styled.div`
    text-align: center;
    width: 20%;
`
const Played = styled.div`
    text-align: center;
    width: 20%;
`
const State = styled.div`
    width: 20%;
`
const CriteriaBoxLeaderboard = () => {
  return (
    <Box>
        <Position>
            ~
        </Position>
        <State>

        </State>
        <PlayerName>
            Nombre
        </PlayerName>
        <Winrate>
            %
        </Winrate>
        <Played>
            Jugados
        </Played>
    </Box>
  )
}

export default CriteriaBoxLeaderboard