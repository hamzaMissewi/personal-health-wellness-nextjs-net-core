'use client';

import { useState } from 'react';
import {
    Card,
    CardContent,
    CardDescription,
    CardHeader,
    CardTitle,
} from '@/components/ui/card';
import { Button } from '@/components/ui/button';
import { Badge } from '@/components/ui/badge';
import { Tabs, TabsContent, TabsList, TabsTrigger } from '@/components/ui/tabs';
import { Activity, Brain, Heart, Target, TrendingUp, User } from 'lucide-react';
import { HealthChat } from './components/health-chat';
import { HealthMetrics } from './components/health-metrics';
import { WellnessPlan } from './components/wellness-plan';
import { HealthInsights } from './components/health-insights';

export default function HealthWellnessApp() {
    const [activeTab, setActiveTab] = useState('dashboard');

    return (
        <div className='min-h-screen bg-gradient-to-br from-blue-50 to-green-50'>
            <header className='bg-white shadow-sm border-b'>
                <div className='max-w-7xl mx-auto px-4 sm:px-6 lg:px-8'>
                    <div className='flex justify-between items-center py-4'>
                        <div className='flex items-center space-x-2'>
                            <Heart className='h-8 w-8 text-red-500' />
                            <h1 className='text-2xl font-bold text-gray-900'>
                                WellnessAI
                            </h1>
                        </div>
                        <div className='flex items-center space-x-4'>
                            <Badge
                                variant='secondary'
                                className='bg-green-100 text-green-800'>
                                <Activity className='h-4 w-4 mr-1' />
                                Active
                            </Badge>
                            <Button variant='outline' size='sm'>
                                <User className='h-4 w-4 mr-2' />
                                Profile
                            </Button>
                        </div>
                    </div>
                </div>
            </header>

            <main className='max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8'>
                <div className='mb-8'>
                    <h2 className='text-3xl font-bold text-gray-900 mb-2'>
                        Your Personal Health Assistant
                    </h2>
                    <p className='text-gray-600'>
                        AI-powered insights for your wellness journey in 2025
                    </p>
                </div>

                <Tabs
                    value={activeTab}
                    onValueChange={setActiveTab}
                    className='space-y-6'>
                    <TabsList className='grid w-full grid-cols-4'>
                        <TabsTrigger
                            value='dashboard'
                            className='flex items-center space-x-2'>
                            <TrendingUp className='h-4 w-4' />
                            <span>Dashboard</span>
                        </TabsTrigger>
                        <TabsTrigger
                            value='chat'
                            className='flex items-center space-x-2'>
                            <Brain className='h-4 w-4' />
                            <span>AI Assistant</span>
                        </TabsTrigger>
                        <TabsTrigger
                            value='plan'
                            className='flex items-center space-x-2'>
                            <Target className='h-4 w-4' />
                            <span>Wellness Plan</span>
                        </TabsTrigger>
                        <TabsTrigger
                            value='insights'
                            className='flex items-center space-x-2'>
                            <Activity className='h-4 w-4' />
                            <span>Insights</span>
                        </TabsTrigger>
                    </TabsList>

                    <TabsContent value='dashboard' className='space-y-6'>
                        <div className='grid grid-cols-1 lg:grid-cols-3 gap-6'>
                            <div className='lg:col-span-2'>
                                <HealthMetrics />
                            </div>
                            <div>
                                <Card>
                                    <CardHeader>
                                        <CardTitle className='flex items-center space-x-2'>
                                            <Brain className='h-5 w-5 text-purple-500' />
                                            <span>AI Recommendations</span>
                                        </CardTitle>
                                        <CardDescription>
                                            Personalized suggestions based on
                                            your health data
                                        </CardDescription>
                                    </CardHeader>
                                    <CardContent className='space-y-4'>
                                        <div className='p-3 bg-blue-50 rounded-lg'>
                                            <p className='text-sm font-medium text-blue-900'>
                                                💧 Hydration Alert
                                            </p>
                                            <p className='text-xs text-blue-700 mt-1'>
                                                You're 2 glasses behind your
                                                daily goal
                                            </p>
                                        </div>
                                        <div className='p-3 bg-green-50 rounded-lg'>
                                            <p className='text-sm font-medium text-green-900'>
                                                🏃 Activity Boost
                                            </p>
                                            <p className='text-xs text-green-700 mt-1'>
                                                Perfect time for a 10-minute
                                                walk
                                            </p>
                                        </div>
                                        <div className='p-3 bg-purple-50 rounded-lg'>
                                            <p className='text-sm font-medium text-purple-900'>
                                                😴 Sleep Optimization
                                            </p>
                                            <p className='text-xs text-purple-700 mt-1'>
                                                Consider winding down in 2 hours
                                            </p>
                                        </div>
                                    </CardContent>
                                </Card>
                            </div>
                        </div>
                    </TabsContent>

                    <TabsContent value='chat'>
                        <HealthChat />
                    </TabsContent>

                    <TabsContent value='plan'>
                        <WellnessPlan />
                    </TabsContent>

                    <TabsContent value='insights'>
                        <HealthInsights />
                    </TabsContent>
                </Tabs>
            </main>
        </div>
    );
}
